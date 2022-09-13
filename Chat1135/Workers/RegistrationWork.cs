using Chat1135;
using ChatTypes;
using System.Text.Json;

internal class RegistrationWork : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {
        if (message.Type == TypeMessage.Registration)
        {
            var regData = JsonSerializer.Deserialize<Registration>(message.Arg.ToString());
            var clients = AllClients.GetInstance();
            if (clients.CheckNameExist(regData.Nickname))
            {
                chatClient.SendMessage(message.Arg.ToString());
                return true;
            }
            // при наличии бд, здесь была бы проверка на логин и пароль в бд
            // если пользователь в бд есть, то получаем его ID и отправляем обратно

            chatClient.Data = regData;
            //  при наличии бд, регистрация в бд нового пользователя
            regData.ID = clients.GetNextClientID();
            chatClient.SendMessage(JsonSerializer.Serialize<Registration>(regData));
            return true;
        }
        else
            return NextWorker?.Work(message, chatClient) ?? false;
    }
}