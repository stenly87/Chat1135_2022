using ChatTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class StateMessaging : IStateChat
{
    private Chat chat;

    public StateMessaging(Chat chat)
    {
        this.chat = chat;
    }

    public string? ConstructSendMessage(string? text)
    {
        if (text.StartsWith("/"))
            return text;
        UserMessage message = new UserMessage
        {
            DateSended = DateTime.Now.ToBinary(),
            Text = text,
            UserID = chat.UserData.ID
        };
        text = ChatTools.CreateMessageToServer(message, TypeMessage.UserMessage);
        return text;
    }

    public string? HandleServerMessage(string? message, Chat chat)
    {
        Console.WriteLine(message);
        return null;
    }
}
