using ChatTypes;

internal class NullWorker : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {
        return false;
    }
}