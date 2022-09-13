internal interface IStateChat
{
    string? ConstructSendMessage(string? text);
    string? HandleServerMessage(string? message, Chat chat);
}