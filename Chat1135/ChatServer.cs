using Chat1135;
using System.Net;
using System.Net.Sockets;

internal class ChatServer
{
    static ChatServer instance;
    public static ChatServer GetInstance()
    {
        if (instance == null)
            instance = new ChatServer("192.168.4.11", 50000);
        return instance;
    }

    TcpListener tcp;
    IPAddress address;

    public bool Running { get; private set; }

    internal void Start()
    {
        if (Running)
            return;
        tcp.Start();
        Running = true;
        while (Running)
        {
            TcpClient client = tcp.AcceptTcpClient();
            Thread thread = new Thread(
                o =>
                {
                    var obj = new ChatClient((TcpClient)o);
                    AllClients.GetInstance().AddClient(obj);
                    obj.Listen();
                });
            thread.Start(client);
        }
    }

    internal void Stop()
    {
        Running = false;
        tcp.Stop();
    }

    private ChatServer(string ipAddress, int port)
    {
        address = IPAddress.Parse(ipAddress);
        tcp = new TcpListener(address, port);
    }
}
