using Chat1135;
using ChatTypes;
using System.Text.Json;

internal class ChatMessaging
{
    static ChatMessaging instance;
    static object lockObject = new object();
    internal static ChatMessaging GetInstance()
    {
        lock (lockObject)
        {
            if (instance == null)
                instance = new ChatMessaging();
            return instance;
        }
    }

    internal void RunMessage(string command)
    {
        Message message = JsonSerializer.Deserialize<Message>(command);
        var userMessage = JsonSerializer.Deserialize<UserMessage>(message.Arg.ToString());
        AllClients.GetInstance().BroadcastMessage(userMessage);
    }

    private ChatMessaging()
    {

    }
}