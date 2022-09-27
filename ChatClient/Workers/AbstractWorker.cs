using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Workers
{
    internal abstract class AbstractWorker
    {
        public AbstractWorker NextWorker { get; set; }
        public virtual MessageArgs CheckCommand(string text, Chat chat)
        {
            if (NextWorker == null)
                return null;
            return NextWorker.CheckCommand(text, chat);
        }
    }
}
