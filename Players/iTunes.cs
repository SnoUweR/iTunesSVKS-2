using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using iTunesLib;

namespace iTunesSVKS_2.Players
{
    class iTunes : IPlayer
    {
        private iTunesApp app;
        private bool _isLaunched;
        private System.Timers.Timer _checkTimer;
        private Song _previousSong;

        public void Initialize()
        {
            app = new iTunesAppClass(){AppCommandMessageProcessingEnabled = true};
            _checkTimer = new Timer();
            _isLaunched = true;
            _checkTimer.Interval = 2000.0;
            _checkTimer.Elapsed += CheckTimerOnElapsed;
            _checkTimer.Enabled = true;
        }

        private void CheckTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (!GetCurrentSong().Equals(_previousSong)) OnSongChanged(GetCurrentSong()); 
        }


        public bool IsLaunched()
        {
            return _isLaunched;
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
                Cover = GetCover(),
            };
            return tmp;
        }

        private Image GetCover()
        {
            IITArtworkCollection art1 = app.CurrentTrack.Artwork;
            IITArtwork art2 = art1[1];
            if (art2 == null) return null;
            art2.SaveArtworkToFile(String.Concat(Environment.CurrentDirectory, @"\Cover.jpg"));
            Stream r = File.Open(String.Concat(Environment.CurrentDirectory, @"\Cover.jpg"), FileMode.Open);
            Image temp = Image.FromStream(r);
            r.Close();
            return temp;
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public event SongChangedEventHandler SongChanged;

        protected virtual void OnSongChanged(Song newsong)
        {
            _previousSong = newsong;
            var handler = SongChanged;
            if (handler != null) handler(this, newsong);
        }
    }
}
