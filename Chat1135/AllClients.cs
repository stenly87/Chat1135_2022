using ChatTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat1135
{
    internal class AllClients
    {
        static int autoincrement = 1;
        static AllClients instance;
        public static AllClients GetInstance()
        { 
            if (instance == null)
                instance = new AllClients();
            return instance;
        }

        internal bool CheckNameExist(string nickname)
        {
            var found = clients.Find(s => s.Data?.Nickname == nickname);
            return found != null;
        }

        List<ChatClient> clients = new List<ChatClient>();

        internal void BroadcastMessage(UserMessage? userMessage)
        {
            var recievers = clients.Where(s => s.Data?.ID != userMessage.UserID);
            var sender = clients.FirstOrDefault(s => s.Data?.ID == userMessage.UserID);
            string message = $"{sender.Data.Nickname}: {userMessage.Text}" ;
            foreach (var client in recievers)
            {
                client.SendMessage(message);
            }
        }

        private AllClients()
        {
        }

        internal void AddClient(ChatClient chatClient)
        {
            clients.Add(chatClient);
        }

        internal void RemoveClient(ChatClient chatClient)
        {
            clients.Remove(chatClient);
        }

        internal int GetNextClientID()
        {
            return autoincrement++;
        }
    }
}
