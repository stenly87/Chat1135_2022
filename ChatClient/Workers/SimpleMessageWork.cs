using ChatClient.Workers;
using ChatTypes;

internal class SimpleMessageWork : AbstractWorker
{
    public override MessageArgs CheckCommand(string text, Chat chat)
    {
        if (!text.StartsWith("/"))
        {
            var msg = new UserMessage
            {
                DateSended = DateTime.Now.ToBinary(),
                Text = text,
                UserID = chat.Info.UserData.ID
            };
            return new MessageArgs { Type = ChatTypes.TypeMessage.UserMessage, Value = msg };
        }
        return base.CheckCommand(text, chat);
    }
}