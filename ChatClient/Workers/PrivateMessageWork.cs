using ChatClient.Workers;
using ChatTypes;

internal class PrivateMessageWork : AbstractWorker
{
    public override MessageArgs CheckCommand(string text, Chat chat)
    {
        if (text.StartsWith("/p "))
        {
            MessageArgs result = new MessageArgs();
            string nick = null;
            if (chat.Info.Online == null)
            {
                result.Type = TypeMessage.ListUsers;
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
                result.Type = TypeMessage.UserMessage;
                result.Value = new UserMessage
                {
                    DateSended = DateTime.Now.ToBinary(),
                    Text = text,
                    UserID = chat.Info.UserData.ID,
                    ReceiverID = receiver.ID
                };
            }
            return result;
        }
        return base.CheckCommand(text, chat);
    }
}