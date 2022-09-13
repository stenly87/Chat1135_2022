using ChatTypes;

internal class CommandsWorker
{
    AbstractWorker rootWorker;

    internal bool Work(Message message, ChatClient chatClient)
    {
        if (rootWorker != null)
            return rootWorker.Work(message, chatClient);
        return false;
    }

    internal void SetWorker(AbstractWorker worker)
    {
        if (rootWorker == null)
            rootWorker = worker;
        else
        {
            worker.SetNextWorker(rootWorker);
            rootWorker = worker;
        }
    }
}