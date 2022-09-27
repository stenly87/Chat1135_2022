using ChatClient.Workers;
using ChatTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


internal class StateMessaging : IStateChat
{
    private readonly Chat chat;
    WorkerCenter workerCenter;

    public StateMessaging(Chat chat)
    {
        workerCenter = new WorkerCenter(chat);
        this.chat = chat;
    }

    public string? ConstructSendMessage(string? text)
    {
        if (text == null)   
            return null;
        var args = workerCenter.TestCommand(text);
        TypeMessage typeMessage;
        object argMessage;
        if (args == null)
        {
            typeMessage = TypeMessage.UserMessage;
            argMessage = new UserMessage
            {
                DateSended = DateTime.Now.ToBinary(),
                Text = text,
                UserID = chat.Info.UserData.ID
            };
        }
        else
        {
            typeMessage = args.Type;
            argMessage = args.Value;
        }
        text = ChatTools.CreateMessageJsonString(argMessage, typeMessage);
        return text;
    }

    public string? HandleServerMessage(string? message, Chat chat)
    {
        Message msg = null;
        try
        {
            msg = JsonSerializer.Deserialize<Message>(message);
        }
        catch { }
        if (msg != null)
        {
            if (msg.Type == TypeMessage.ListUsers)
            {
                ListUsers list = JsonSerializer.Deserialize<ListUsers>(msg.Arg.ToString());
                chat.Info.SetOnlineData(list);
                chat.Info.ViewOnline();
            }
        }
        else
            Console.WriteLine(message);
        return null;
    }
}
