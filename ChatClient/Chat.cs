using ChatTypes;
using System.Net;
using System.Net.Sockets;

internal class Chat
{
    public ChatInfo Info { get; set; }
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
        Info = new ChatInfo();
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
            client = new TcpClient(new IPEndPoint(IPAddress.Any,  50001 + new Random().Next(1, 1000)));
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
            Console.Write("-> ");
            string text = Console.ReadLine();
            if (text == "/exit")
                running = false;
            text = stateChat.ConstructSendMessage(text);
            if (text != null)
            {
                writer.WriteLine(text);
                writer.Flush();
            }
        }
    }

    private void ListenServer(StreamReader o)
    {
        while (running)
        {
            string message = reader.ReadLine();
            if (message != null)
            {
                message = stateChat.HandleServerMessage(message, this);
                if (message == "/exit")
                    break;
            }
        }
    }

    
}