using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTypes
{
    public class Message
    {
        public TypeMessage Type { get; set; }
        public object Arg { get; set; }
    }
}
