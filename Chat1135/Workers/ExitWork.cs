using ChatTypes;

internal class ExitWork : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {
        if (message.Type == TypeMessage.Exit)
        {
            chatClient.SendMessage("/exit");
            chatClient.Disconnect();
            return true;
        }
        return NextWorker?.Work(message, chatClient) ?? false;
    }
}