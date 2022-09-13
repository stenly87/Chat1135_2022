using ChatTypes;

internal class ListUserWork : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {

        return NextWorker?.Work(message, chatClient) ?? false;
    }
}