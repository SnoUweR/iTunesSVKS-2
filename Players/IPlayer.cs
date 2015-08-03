using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.Players
{
    interface IPlayer
    {
        void Initialize();

        bool IsLaunched();

        Song GetCurrentSong();

        void Destroy();

        event SongChangedEventHandler SongChanged;
    }

    internal delegate void SongChangedEventHandler(object sender, Song newsong);
}
