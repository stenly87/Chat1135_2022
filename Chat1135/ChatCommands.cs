internal class ChatCommands
{
    static ChatCommands instance;
    internal static ChatCommands GetInstance()
    {
        if (instance == null)  
            instance = new ChatCommands();  
        return instance;    
    }

    internal bool RunCommand(string? command, ChatClient chatClient)
    {
        if (command == null)
            return true;
        if (command == "/exit")
        {
            chatClient.SendMessage("/exit");
            chatClient.Disconnect();
            return true;
        }

        return false;
    }
}