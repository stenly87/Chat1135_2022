﻿using ChatTypes;
using System.Net.Sockets;

internal class ChatClient
{
    public TcpClient Client { get; }

    private NetworkStream baseStream;
    private StreamWriter writer;
    private StreamReader reader;

    public Registration Data { get; set; }

    public ChatClient(TcpClient client)
    {
        Client = client;
        try
        {
            baseStream = Client.GetStream();
            writer = new StreamWriter(baseStream);
            reader = new StreamReader(baseStream);
        }
        catch { }
    }

    public void Listen()
    {
        while (ChatServer.GetInstance().Running)
        {
            string command = reader.ReadLine();
            ChatMessaging.GetInstance().RunCommand(command);
        }
    }

    public void SendMessage(string text)
    {
        try
        {
            writer.WriteLine(text);
            writer.Flush();
        }
        catch { }
    }

    public void Disconnect()
    {
        try
        {
            baseStream.Close();
            baseStream.Dispose();
        }
        catch { }
    }
}