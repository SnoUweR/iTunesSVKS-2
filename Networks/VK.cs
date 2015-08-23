using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiCore;
using ApiCore.Audio;
using ApiCore.Friends;
using ApiCore.Messages;
using ApiCore.Status;
using iTunesSVKS_2.Common;
using Friend = iTunesSVKS_2.Common.Friend;

namespace iTunesSVKS_2.Networks
{
    class VK : INetwork, ISharer
    {
        private bool _isLogged;
        private SessionManager _sessionManager;
        private SessionInfo _sessionInfo;
        private ApiManager _manager;
        private StatusFactory _statusFactory;
        private FriendsFactory _friendsFactory;
        private AudioFactory _audioFactory;
        private MessagesFactory _messagesFactory;

        private bool _needRelogin;

        public void Auth()
        {
             _sessionManager = new SessionManager(2369574, "status,wall,photos,audio,messages");
            if (_needRelogin)
            {
                _sessionManager.ReLogin();
                _isLogged = false;
                _needRelogin = false;
            }
            //OnConnecting();
            if (!_isLogged)
            {

                // Соединяемся с VK API, передаем ему ключ приложения и необходимые нам разрешения
               
                _sessionInfo = _sessionManager.GetOAuthSession();
                if (_sessionInfo != null)
                {
                    _isLogged = true;
                }
                Auth();
            }

            // Выполняется если пользователь залогинен
            else
            {
                _manager = new ApiManager(_sessionInfo) { Timeout = 10000 };
                _statusFactory = new StatusFactory(_manager);
                _friendsFactory = new FriendsFactory(_manager);
                _audioFactory = new AudioFactory(_manager);
                _messagesFactory = new MessagesFactory(_manager);
                OnConnected(_sessionInfo.UserId.ToString());
            }
        }

        public bool GetLoginStatus()
        {
            return _isLogged;
        }

        public string GetStatus()
        {
            return _statusFactory.Get(_sessionInfo.UserId);
        }

        public void SetStatus(string status)
        {
            _statusFactory.Set(status);
        }

        public void Deauth()
        {
            _needRelogin = true;
            // Эта штука тянется еще с первой версии. Неужели нет лучшего способа?
            //_sessionManager.ReLogin();
            //_isLogged = false;
            Auth();
        }

        public void Share(string id, string message)
        {
            _messagesFactory.Send(Convert.ToInt32(id), message, "", SendMessageType.FromChat);
        }

        public List<Friend> GetFriends()
        {
            List<Friend> tmpList = new  List<Friend>();
            string[] fields = { "uid", "first_name", "last_name" };
            List<ApiCore.Friends.Friend> friendsList = _friendsFactory.Get(_sessionInfo.UserId, "nom", null, 0, null, fields);

            foreach (ApiCore.Friends.Friend f in friendsList)
            {
                tmpList.Add(new Friend(f.Id.ToString(), String.Format("{0} {1}", f.FirstName, f.LastName)));
            }
            return tmpList;
        }

        public void SetBroadcast(AudioEntry audio)
        {
            _audioFactory.SetBroadcast(String.Format("{0}_{1}", audio.OwnerId, audio.Id));
        }

        public AudioEntry SearchAudio(Song song)
        {
            return _audioFactory.Search(String.Format("{0} {1}", song.Artist, song.Name), AudioSortOrder.ByPopularity,
                false, 1, 0, false).First();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public string GetNetworkName()
        {
            return "VK";
        }

        public event ConnectedEventHandler Connected;
        public event ConnectingEventHandler Connecting;

        protected virtual void OnConnected(string username)
        {
            var handler = Connected;
            if (handler != null) handler(this, username);
        }

        protected virtual void OnConnecting()
        {
            var handler = Connecting;
            if (handler != null) handler(this, GetNetworkName());
        }
    }
}
