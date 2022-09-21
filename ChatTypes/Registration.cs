using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTypes
{
    public class Registration
    {
        public string Nickname { get; set; }
        public string Password { get; set; } 
        public int ID { get; set; }
        public int ErrorCode { get; set; }
    }
}
