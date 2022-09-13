using System.Text.Json;
using ChatTypes;

internal class ChatCommands
{
    static ChatCommands instance;
    private CommandsWorker worker;

    private ChatCommands()
    {
        worker = new CommandsWorker();
        worker.SetWorker(new NullWorker());
        worker.SetWorker(new RegistrationWork());
        worker.SetWorker(new ListUserWork());
    }

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

        Message message = JsonSerializer.Deserialize<Message>(command);
        if (message == null)
            return false;

        return worker.Work(message, chatClient);
    }
}