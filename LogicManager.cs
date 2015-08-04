using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Networks;
using iTunesSVKS_2.Players;
using iTunesSVKS_2.TemplateProcessor;
using iTunesSVKS_2.Networks.LastFM;
using iTunesSVKS_2.Common;


namespace iTunesSVKS_2
{
    class LogicManager
    {
        public bool AutoScrobble { get; set; }

        public enum NetworkOptions
        {
            Base = 2,
            Sharing = 4,
        }

        public enum PlayerOptions
        {
            Base = 2,
            CoverSet = 4,
        }

        private void CheckOptions(INetwork network, IPlayer player)
        {
            
        }

        public void Start()
        {
            
        }
    }
}
