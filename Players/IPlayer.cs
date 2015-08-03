using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.Players
{
    interface IPlayer
    {
        void Initialize();
        Song GetCurrentSong();

        void Destroy();
    }
}
