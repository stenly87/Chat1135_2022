using ChatClient.Workers;
using ChatTypes;

internal class BanWork : AbstractWorker
{
    public override MessageArgs CheckCommand(string text, Chat chat)
    {
        if (text.StartsWith("/ban ")) // /ban nick
        {
            MessageArgs result = new MessageArgs();
            if (chat.Info.Online == null)
            {
                result.Type = TypeMessage.ListUsers;
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
                result.Type = TypeMessage.BanUser;
                result.Value = userToBan.ID;
            }
            return result;
        }
        return base.CheckCommand(text, chat);
    }
}