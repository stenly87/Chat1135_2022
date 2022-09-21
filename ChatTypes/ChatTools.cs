using ChatTypes;
using System.Text.Json;

public static class ChatTools
{
    public static void StartThreadReader(object arg1, Action<object> action)
    {
        Thread thread = new Thread(o => action(o));
        thread.Start(arg1);
    }

    public static string CreateMessageJsonString(object arg1, TypeMessage type)
    {
        Message message = new Message
        {
            Type = type,
            Arg = arg1
        };
        return JsonSerializer.Serialize<Message>(message);
    }
}