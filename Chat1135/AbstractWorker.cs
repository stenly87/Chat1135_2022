using ChatTypes;

internal abstract class AbstractWorker
{
    public AbstractWorker NextWorker { get; set; }
    public void SetNextWorker(AbstractWorker nextWorker)
    {
        NextWorker = nextWorker;
    }
    public abstract bool Work(Message message, ChatClient chatClient);
}