using ChatClient.Workers;

internal class ListUserWork : AbstractWorker
{
    public override MessageArgs CheckCommand(string text, Chat chat)
    {
        if (text == "/listusers")
            return new MessageArgs { Type = ChatTypes.TypeMessage.ListUsers };
        return base.CheckCommand(text, chat);
    }
}