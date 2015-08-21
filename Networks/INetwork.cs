using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks
{
    interface INetwork
    {
        void Auth();

        bool GetLoginStatus();

        string GetStatus();
        void SetStatus(string status);

        void Deauth();

        void Destroy();

        string GetNetworkName();

        event ConnectedEventHandler Connected;

        event ConnectingEventHandler Connecting;
    }

    internal delegate void ConnectedEventHandler(object sender, string username);

    internal delegate void ConnectingEventHandler(object sender, string networkName);
}
