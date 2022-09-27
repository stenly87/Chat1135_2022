using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Workers
{
    internal class WorkerCenter
    {
        private readonly Chat chat;
        AbstractWorker firstWorker;

        public WorkerCenter(Chat chat)
        {
            this.chat = chat;

            SetNextWorker(new SimpleMessageWork());
            SetNextWorker(new ExitWork());
            SetNextWorker(new ListUserWork());
            SetNextWorker(new PrivateMessageWork());
            SetNextWorker(new BanWork());
        }

        private void SetNextWorker(AbstractWorker simpleMessageWork)
        {
            if (firstWorker != null)
                simpleMessageWork.NextWorker = firstWorker;
            firstWorker = simpleMessageWork;
        }

        internal MessageArgs TestCommand(string? text)
        {
            return firstWorker?.CheckCommand(text, chat);
        }
    }
}
