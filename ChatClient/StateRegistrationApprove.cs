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
        Console.WriteLine(message);
        return null;
    }
}