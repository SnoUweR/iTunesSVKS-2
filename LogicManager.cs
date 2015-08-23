using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTunesSVKS_2.Networks;
using iTunesSVKS_2.Players;
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
        /// <summary>
        /// Первоначальный статус, который стоял у пользователя до работы программы
        /// </summary>
        public string InitialStatus { get; set; }
        
        /// <summary>
        /// Определяет, нужно ли автоматически обновлять статус после смены композиции
        /// </summary>
        public bool AutoScrobble { get; set; }


        /// <summary>
        /// Возвращает объект, который представляет текущую (или последнюю) композицию
        /// </summary>
        public Song CurrentSong { get; private set; }

        /// <summary>
        /// Статус, который установится после обновления композиции. 
        /// Должен содержать уже обработанные тэги!
        /// </summary>
        public string StatusToChange { get; set; }

        // В случае с VK, если это будет False, то каждый раз будет 
        // показываться окошко, где нужно подтвердить разрешения приложения
        // Это удобно в тех случаях, когда нужно зайти под другим юзером

        /// <summary>
        /// Нужно ли производить автоматическую авторизацию
        /// </summary>
        public bool AutoLogin { get; set; }

        // Я думаю, это как-то понаркомански поступаю, но пол пятого утра, так что..
        public event ConnectedEventHandler Connected;
        public event SongChangedEventHandler SongChanged;
        //А сейчас уже десять утра, так что у тебя нет оправдания для этой херни
        public event ConnectingEventHandler Connecting;

        private INetwork net;
        private IPlayer player;

        public LogicManager()
        {
            
        }

        /// <summary>
        /// Возвращает текущий статус в активной социальной сети
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            return net.GetStatus();
        }

        /// <summary>
        /// Возвращает объект активной социальной сети
        /// </summary>
        /// <returns></returns>
        public INetwork GetNetworkHandler()
        {
            return net;
        }

        /// <summary>
        /// Возвращает объект активного плеера
        /// </summary>
        /// <returns></returns>
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

        [Flags]
        public enum NetworkOptionsEnum
        {
            Base = 2,
            Sharing = 4,
            CoverFind = 8,
        }

        [Flags]
        public enum PlayerOptionsEnum
        {
            Base = 2,
            CoverSet = 4,
        }

        public NetworkOptionsEnum NetworkOptions { get; private set; }
        public PlayerOptionsEnum PlayerOptions { get; private set; }

        /// <summary>
        /// Проверяет, какие дополнительные функции поддерживает плеер и социальная сеть.
        /// Возможно, это стоит делать менее захардкодерно, но пока так.
        /// TODO: Сделать, чтоб норм было
        /// </summary>
        private void CheckOptions()
        {
            NetworkOptions = NetworkOptionsEnum.Base;
            PlayerOptions = PlayerOptionsEnum.Base;

            if (this.GetNetworkHandler() is ISharer) NetworkOptions |= NetworkOptionsEnum.Sharing;

            //TODO: У меня пока нет классов, которые попадали бы в эту категорию
            //Может вообще их не наследовать от нетворк, а делать как что-то отдельное?
            if (this.GetNetworkHandler() is ICoverFinder) NetworkOptions |= NetworkOptionsEnum.CoverFind;

            if (this.GetPlayerHandler() is ICoverSetter) PlayerOptions |= PlayerOptionsEnum.CoverSet;
        }

        public void Start()
        {
            TaskFactory tf = new TaskFactory();
            net = new VK();

            AutoLogin = false;
   
            player = new iTunes();

            CheckOptions();

            player.SongChanged += PlayerOnSongChanged;
            net.Connected += NetOnConnected;
            net.Connecting += OnConnecting;

            //tf.StartNew(delegate
            //{
            //    net.Auth();
            //});
            if (!AutoLogin) net.Deauth();
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

        protected virtual void OnConnecting(object sender, string networkName)
        {
            var handler = Connecting;
            if (handler != null) handler(this, networkName);
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

        /// <summary>
        /// Принудительно обновляет статус
        /// </summary>
        public void ForceUpdateStatus()
        {
            net.SetStatus(StatusToChange);
        }
    }
}
