using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat1135
{
    internal class AllClients
    {
        static AllClients instance;
        public static AllClients GetInstance()
        { 
            if (instance == null)
                instance = new AllClients();
            return instance;
        }

        List<ChatClient> clients = new List<ChatClient>();

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
    }
}
