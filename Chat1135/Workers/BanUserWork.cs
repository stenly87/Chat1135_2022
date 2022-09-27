using Chat1135;
using ChatTypes;
using System.Text.Json;

internal class BanUserWork : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {
        if (message.Type == TypeMessage.BanUser)
        {
            int id = JsonSerializer.Deserialize<int>(message.Arg.ToString());
            AllClients.GetInstance().BanUser(id);
            return true;
        }
        return NextWorker?.Work(message, chatClient) ?? false;
    }
}