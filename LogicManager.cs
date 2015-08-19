using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using iTunesSVKS_2.Networks;
using iTunesSVKS_2.Players;
using iTunesSVKS_2.TemplateProcessor;
using iTunesSVKS_2.Networks.LastFM;
using iTunesSVKS_2.Common;


namespace iTunesSVKS_2
{
    /// <summary>
    /// Данный класс, наверное, в будущем будет реализовывать
    /// всю логику вида ПЛЕЕР <=> СОЦ. СЕТЬ
    /// </summary>
    class LogicManager
    {
        public string InitialStatus { get; set; }
        
        public bool AutoScrobble { get; set; }

        public Song CurrentSong { get; private set; }

        public string StatusToChange { get; set; }

        // Я думаю, это как-то понаркомански поступаю, но пол пятого утра, так что..
        public event ConnectedEventHandler Connected;
        public event SongChangedEventHandler SongChanged;

        private INetwork net;
        private IPlayer player;

        public LogicManager()
        {

        }

        public string GetStatus()
        {
            return net.GetStatus();
        }

        public INetwork GetNetworkHandler()
        {
            return net;
        }

        public IPlayer GetPlayerHandler()
        {
            return player;
        }

        /// <summary>
        /// Должен вызываться, когда завершается работа с программой
        /// </summary>
        public void Close()
        {
            net.SetStatus(InitialStatus);
        }

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
            net = new Skype();
            player = new iTunes();


            player.SongChanged += PlayerOnSongChanged;
            net.Connected += NetOnConnected;

            net.Auth();
            player.Initialize();

        }

        private void NetOnConnected(object sender, string username)
        {
            OnConnected(username);
        }

        protected virtual void OnConnected(string username)
        {
            var handler = Connected;
            if (handler != null) handler(this, username);
        }

        protected virtual void OnSongChanged(Song newsong)
        {
            var handler = SongChanged;
            if (handler != null) handler(this, newsong);
        }

        private void PlayerOnSongChanged(object sender, Song newsong)
        {
            CurrentSong = newsong;
            OnSongChanged(CurrentSong);

            Console.WriteLine("Песня изменилась на {0}", CurrentSong);

            if (AutoScrobble)
            {
                net.SetStatus(StatusToChange);
            }
        }

        public void ForceUpdateStatus()
        {
            net.SetStatus(StatusToChange);
        }
    }
}
