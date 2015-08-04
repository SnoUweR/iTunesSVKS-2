using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks
{
    interface ISharer
    {
        void Share(string id, string message);

        List<Friend> GetFriends();
    }
}
