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
            ListenServer();
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
        throw new NotImplementedException();
    }

    private void ListenServer()
    {
        throw new NotImplementedException();
    }

    public Chat(string ip, int port)
    {
        ipServer = IPAddress.Parse(ip);
        this.port = port;
    }
}