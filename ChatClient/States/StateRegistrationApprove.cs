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
            if (data.ErrorCode == 1)
                Console.WriteLine("Имя занято. Зарегистрируйтесь заново");
            else if (data.ErrorCode == 2)
                Console.WriteLine("Имя не должно содержать пробелов. Зарегистрируйтесь заново");
            chat.SetState(new StateRegistration(chat));
        }
        else
        {
            chat.Info.SetUserData(data);
            Console.WriteLine($"Вы зарегистрированы на сервере с ником {data.Nickname}");
            chat.SetState(new StateMessaging(chat));
        }
        return null;
    }
}