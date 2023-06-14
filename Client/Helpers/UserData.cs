using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public string RemoteEndPoint { get; set; }
        public UserData() 
        {
        
        }
    }
}
