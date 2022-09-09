using ChatTypes;
using System.Text.Json;

internal class StateRegistration : IStateChat
{
    Registration registration = new Registration();
    private Chat chat;

    public StateRegistration(Chat chat)
    {
        this.chat = chat;
        Console.WriteLine("Введите ник для регистрации");
    }

    public string? ConstructSendMessage(string? text)
    {
        if (registration.Nickname == null)
        {
            Console.WriteLine("Введите пароль для регистрации");
            registration.Nickname = text;
        }
        else if (registration.Password == null)
        {
            registration.Password = text;
            string json = JsonSerializer.Serialize<Registration>(registration);
            chat.SetState(new StateRegistrationApprove(chat));
            return json;
        }
        return null;
    }

    public string? HandleServerMessage(string? message, Chat chat)
    {
        return null;
    }
}