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
        Console.WriteLine(command);
    }

    private ChatMessaging()
    {
    }
}