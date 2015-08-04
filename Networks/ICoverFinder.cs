﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks
{
    interface ICoverFinder
    {
        bool FindCover(Song song);

        Image GetCoverImage();

        string GetImagePath();
    }
}
