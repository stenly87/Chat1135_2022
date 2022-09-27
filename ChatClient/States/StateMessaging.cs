using ChatTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        object argMessage = null;
        TypeMessage typeMessage = TypeMessage.UserMessage;
        if (!text.StartsWith("/"))
        {
            argMessage = new UserMessage
            {
                DateSended = DateTime.Now.ToBinary(),
                Text = text,
                UserID = chat.Info.UserData.ID
            };
        }
        else if (text == "/exit")
            typeMessage = TypeMessage.Exit;
        else if (text == "/listusers")
            typeMessage = TypeMessage.ListUsers;
        else if (text.StartsWith("/ban "))
        {
            string nick = null;
            var receiver = chat.
                    Info.
                    Online.
                    OnlineUsers.
                    FirstOrDefault(s => s.Nickname == nick);
            argMessage = receiver.ID;
            typeMessage = TypeMessage.Ban;
        }
        else if (text.StartsWith("/p "))
        {
            string nick = null;
            if (chat.Info.Online == null)
            {
                typeMessage = TypeMessage.ListUsers;
                Console.WriteLine("Запрос списка пользователей. Повторите сообщение");
            }
            else
            {
                for (int i = 3; i < text.Length; i++)
                    if (text[i] == ' ')
                    {
                        nick = text.Substring(3, i - 3);
                        text = text.Substring(i).Trim();
                        break;
                    }
                var receiver = chat.
                    Info.
                    Online.
                    OnlineUsers.
                    FirstOrDefault(s => s.Nickname == nick);
                if (receiver == null)
                {
                    Console.WriteLine("Нет такого пользователя в локальном списке");
                    chat.Info.ViewOnline();
                    return null;
                }
                argMessage = new UserMessage
                {
                    DateSended = DateTime.Now.ToBinary(),
                    Text = text,
                    UserID = chat.Info.UserData.ID,
                    ReceiverID = receiver.ID
                };
            }
        }
        else if (text.StartsWith("/ban ")) // /ban nick
        {
            if (chat.Info.Online == null)
            {
                typeMessage = TypeMessage.ListUsers;
                Console.WriteLine("Запрос списка пользователей. Повторите сообщение");
            }
            else
            {
                string nick = text.Split()[1];
                var userToBan = chat.
                        Info.
                        Online.
                        OnlineUsers.
                        FirstOrDefault(s => s.Nickname == nick);
                if (userToBan == null)
                {
                    Console.WriteLine("Пользователь не найден");
                    return null;
                }
                typeMessage = TypeMessage.BanUser;
                argMessage = userToBan.ID;
            }
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
