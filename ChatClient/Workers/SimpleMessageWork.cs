using ChatClient.Workers;

internal class SimpleMessageWork : AbstractWorker
{
    public override MessageArgs CheckCommand(string text, Chat chat)
    {
        if (!text.StartsWith("/"))
            return new MessageArgs { Type = ChatTypes.TypeMessage.UserMessage, Value = text };
        return base.CheckCommand(text, chat);
    }
}