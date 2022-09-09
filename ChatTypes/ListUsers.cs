using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTypes
{
    public class ListUsers
    {
        public class PublicUser
        { 
            public string Nickname { get; set; }
            public int ID { get; set; }
        }

        public List<PublicUser> OnlineUsers { get; set; }
            = new List<PublicUser>();
    }
}
