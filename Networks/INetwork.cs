using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.Networks
{
    interface INetwork
    {
        void Auth();

        bool GetLoginStatus();

        string GetStatus();
        void SetStatus(string status);

        void Deauth();

        void Share(string id, string message);

        List<Friend> GetFriends();

        void Destroy();

        event ConnectedEventHandler Connected;
    }

     internal delegate void ConnectedEventHandler(object sender, string username);
}
