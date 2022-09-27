using ChatClient.Workers;

internal class ExitWork : AbstractWorker
{
    public override MessageArgs CheckCommand(string text, Chat chat)
    {
        if (text == "/exit")
            return new MessageArgs { Type = ChatTypes.TypeMessage.Exit };
        return base.CheckCommand(text, chat);
    }
}