using ChatTypes;

internal class ListUserWork : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {
        if (NextWorker != null)
            return NextWorker.Work(message, chatClient);

        return false;
    }
}