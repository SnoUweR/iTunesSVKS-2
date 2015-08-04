using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.Common
{
    class Friend
    {
        public string Id { get; private set; }
        
        public string Username { get; private set; }

        public Friend(string id,  string username)
        {
            Id = id;
            Username = username;
        }


        public override string ToString()
        {
            return Username;
        }
    }
}
