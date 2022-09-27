using ChatTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Workers
{
    internal class MessageArgs
    {
        public TypeMessage Type { get; internal set; }
        public object Value { get; internal set; }
    }
}
