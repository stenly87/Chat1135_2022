using System.Net;
using System.Net.Sockets;

internal class Chat
{
    IPAddress ipServer;
    TcpClient client;
    readonly int port;
    private NetworkStream baseStream;
    private StreamWriter writer;
    private StreamReader reader;
    bool running = false;
    IStateChat stateChat;

    public Chat(string ip, int port)
    {
        ipServer = IPAddress.Parse(ip);
        this.port = port;
        stateChat = new StateRegistration(this);
    }

    public void SetState(IStateChat newState)
    {
        stateChat = newState;
    }

    internal void Connect()
    {
        try
        {
            client = new TcpClient(new IPEndPoint(IPAddress.Any, 50001));
            client.Connect(
                new IPEndPoint(ipServer, port));
            baseStream = client.GetStream();
            writer = new StreamWriter(baseStream);
            reader = new StreamReader(baseStream);
            running = true;
            ChatTools.StartThreadReader(reader,
                (o) => ListenServer((StreamReader)o));
            StartMessaging();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    private void StartMessaging()
    {
        while (running)
        {
            Console.Write("Your message: ");
            string text = Console.ReadLine();
            text = stateChat.ConstructSendMessage(text);
            if (text != null)
            {
                writer.WriteLine(text);
                writer.Flush();
                if (text == "/exit")
                {
                    running = false;
                    break;
                }
            }
        }
    }

    private void ListenServer(StreamReader o)
    {
        while (running)
        {
            string message = reader.ReadLine();
            message = stateChat.HandleServerMessage(message, this);
            if (message == "/exit")
                break;
        }
    }

    
}