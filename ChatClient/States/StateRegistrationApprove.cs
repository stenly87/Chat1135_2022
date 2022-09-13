using ChatTypes;
using System.Text.Json;

internal class StateRegistrationApprove : IStateChat
{
    private Chat chat;
    public StateRegistrationApprove(Chat chat)
    {
        this.chat = chat;
    }

    public string? ConstructSendMessage(string? text)
    {
        return null;
    }

    public string? HandleServerMessage(string? message, Chat chat)
    {
        var data = JsonSerializer.Deserialize<Registration>(message);
        if (data.ID == 0)
        {
            Console.WriteLine("Имя занято. Зарегистрируйтесь заново");
            chat.SetState(new StateRegistration(chat));
        }
        else
        {
            chat.UserData = data;
            Console.WriteLine($"Вы зарегистрированы на сервере с ником {data.Nickname}");
            chat.SetState(new StateMessaging(chat));
        }
        return null;
    }
}