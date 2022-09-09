using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTypes
{
    public class Message
    {
        public string Text { get; set; }
        public long DateSended { get; set; }
        public int UserID { get; set; }
        public int ReceiverID { get; set; } // 0 - всем
    }
}
