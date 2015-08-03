using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiCore;

namespace iTunesSVKS_2.Networks
{
    class VK : INetwork
    {
        private bool _isLogged;
        private SessionInfo _sessionInfo;
        private ApiManager _manager;

        public delegate void ConnectedEventHandler(object sender, string username);
        public event ConnectedEventHandler Connected;


        public void Auth()
        {
            if (!_isLogged)
            {
                // Соединяемся с VK API, передаем ему ключ приложения и необходимые нам разрешения
                var sm = new SessionManager(2369574, "status,wall,photos,audio");
                _sessionInfo = sm.GetOAuthSession();
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
                OnConnected(_sessionInfo.UserId.ToString());
            }
        }

        public bool GetLoginStatus()
        {
            return _isLogged;
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }

        public void SetStatus(string status)
        {
            throw new NotImplementedException();
        }

        public void Deauth()
        {
            throw new NotImplementedException();
        }

        public void Share(string id, string message)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetFriends()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnConnected(string username)
        {
            var handler = Connected;
            if (handler != null) handler(this, username);
        }
    }
}
