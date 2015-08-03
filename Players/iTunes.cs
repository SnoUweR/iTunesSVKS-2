using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesLib;

namespace iTunesSVKS_2.Players
{
    class iTunes : IPlayer
    {
        private iTunesApp app;
        public void Initialize()
        {
            app = new iTunesAppClass();
        }

        public Song GetCurrentSong()
        {
            Song tmp = new Song()
            {
                Album = app.CurrentTrack.Album,
                Artist = app.CurrentTrack.Artist,
                Count = app.CurrentTrack.PlayedCount,
                Genre = app.CurrentTrack.Genre,
                Name = app.CurrentTrack.Name,
                Playlist = app.CurrentTrack.Playlist.Name,
            };
            return tmp;
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
