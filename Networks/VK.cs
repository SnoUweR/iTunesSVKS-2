using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore;
using ApiCore.AttachmentTypes;
using ApiCore.Audio;
using ApiCore.Friends;
using ApiCore.Messages;
using ApiCore.Photos;
using ApiCore.Status;
using ApiCore.Wall;
using iTunesSVKS_2.Common;
using Newtonsoft.Json.Linq;
using Friend = iTunesSVKS_2.Common.Friend;

namespace iTunesSVKS_2.Networks
{
    class VK : INetwork, ISharer, ICoverUploader
    {
        private bool _isLogged;
        private SessionManager _sessionManager;
        private SessionInfo _sessionInfo;
        private ApiManager _manager;
        private StatusFactory _statusFactory;
        private FriendsFactory _friendsFactory;
        private AudioFactory _audioFactory;
        private MessagesFactory _messagesFactory;
        private PhotosFactory _photosFactory;
        private WallFactory _wallFactory;

        private bool _needRelogin;

        public enum ShareDestinations
        {
            Messages, 
            Wall
        }

        public ShareDestinations ShareDestionation { get; set; }

        public bool UploadCover { get; set; }

        public string CoverPath { get; set; }

        public void Auth()
        {
            //чтобы форма с авторизацией не фризила поток, а продолжала свою работу сразу после эвента
            //https://stackoverflow.com/questions/1916095/how-do-i-make-an-eventhandler-run-asynchronously
            //Task.Factory.FromAsync(
            //    (asyncCallback, @object) =>
            //    {
            //        var onConnecting = this.Connecting;
            //        return onConnecting != null ? onConnecting.BeginInvoke(this, GetNetworkName(), asyncCallback, @object) : null;
            //    },
            //    this.Connecting.EndInvoke, null);

            OnConnecting();
            ShareDestionation = ShareDestinations.Messages;
             _sessionManager = new SessionManager(2369574, "status,wall,photos,audio,messages");
            if (_needRelogin)
            {
                _sessionManager.ReLogin();
                _isLogged = false;
                _needRelogin = false;
            }
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
                _photosFactory = new PhotosFactory(_manager);
                _wallFactory = new WallFactory(_manager);
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
            //Auth();
        }

        public void Share(string id, string message)
        {
            //TODO: Тут несколько раз повторяются похожие действие. Может удастся потом как-нибудь отрефакторить?
            PhotoEntryFull photoEntry = null;
            if (UploadCover)
            {
                PhotoUploadedInfo uploadResp = UploadPhoto(_sessionInfo.UserId, CoverPath);
                photoEntry = _photosFactory.SaveWallPhoto(uploadResp, null, null);
            }
            if (ShareDestionation == ShareDestinations.Messages)
            {
                if (UploadCover && photoEntry != null)
                {
                    _messagesFactory.Send(Convert.ToInt32(id), message, "",
                        new MessageAttachment[]
                        {new MessageAttachment(AttachmentType.Photo, photoEntry.OwnerId, photoEntry.Id)});

                }
                else
                {
                    _messagesFactory.Send(Convert.ToInt32(id), message, "", SendMessageType.FromChat);
                }
            }
            else if (ShareDestionation == ShareDestinations.Wall)
            {
                if (UploadCover && photoEntry != null)
                {
                    _wallFactory.Post(Convert.ToInt32(id), message,
                        new MessageAttachment[]
                        {new MessageAttachment(AttachmentType.Photo, photoEntry.OwnerId, photoEntry.Id)});

                }
                else
                {
                    _wallFactory.Post(Convert.ToInt32(id), message);
                }
            }

        }

        private PhotoUploadedInfo UploadPhoto(int userId, string photoPath)
        {
            HttpUploaderFactory uf = new HttpUploaderFactory();
            NameValueCollection files = new NameValueCollection();

            string uploadUrl = _photosFactory.GetWallUploadServer(userId, null);
            files.Add("photo", photoPath);

            PhotoUploadedInfo ui = new PhotoUploadedInfo(uf.Upload(uploadUrl, null, files));

            return ui;
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
