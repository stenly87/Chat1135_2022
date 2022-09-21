using ChatTypes;

internal class ChatInfo
{
    internal Registration UserData { get; set; }
    internal ListUsers Online { get; set; }

    internal void SetUserData(Registration data)
    {
        UserData = data;
    }

    internal void SetOnlineData(ListUsers? list)
    {
        Online = list;
    }

    internal void ViewOnline()
    {
        Console.WriteLine("Пользователи онлайн:");
        Online.OnlineUsers.ForEach(s => Console.WriteLine($"{s.ID} {s.Nickname}"));
    }
}