using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks.LastFM
{
    class Album
    {
        public string Name { get; set; }

        public string Artist { get; set; }

        public int? Id { get; set; }

        public string Url { get; set; }

        public Cover.CoverSizes Covers { get; set; }
    }
}
