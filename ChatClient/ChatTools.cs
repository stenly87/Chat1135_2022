internal static class ChatTools
{
    public static void StartThreadReader(object arg1, Action<object> action)
    {
        Thread thread = new Thread(o => action(o));
        thread.Start(arg1);
    }
}