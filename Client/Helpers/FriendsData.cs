using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    public class FriendsData
    {
        public readonly int UserID;
        public readonly string UserName;
        public readonly string UserDisplayName;
        public readonly DateTime UserCreationDate;


        public FriendsData(int UserID, string UserName, string UserDisplayName, DateTime UserCreationDate) 
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.UserDisplayName = UserDisplayName;
            this.UserCreationDate = UserCreationDate;
        }
    }
}
