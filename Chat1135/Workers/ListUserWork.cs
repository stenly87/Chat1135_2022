using Chat1135;
using ChatTypes;
using System.Text.Json;

internal class ListUserWork : AbstractWorker
{
    public override bool Work(Message message, ChatClient chatClient)
    {
        if(message.Type == TypeMessage.ListUsers)
        { 
            ListUsers list = AllClients.GetInstance().GetOnlineUsers();
            chatClient.SendMessage(
                ChatTools.CreateMessageJsonString(
                    list, TypeMessage.ListUsers));
            return true;
        }
        return NextWorker?.Work(message, chatClient) ?? false;
    }
}