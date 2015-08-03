using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.Networks
{
    interface ICoverFinder
    {
        Image FindCover(Song song);
    }
}
