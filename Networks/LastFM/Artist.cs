using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks.LastFM
{
    class Artist
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int Listeners { get; set; }

        public int Playcount { get; set; }

        public Cover.CoverSizes Covers { get; set; }
    }
}
