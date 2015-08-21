using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using iTunesSVKS_2.Common;
using SKYPE4COMLib;

namespace iTunesSVKS_2.Networks
{
    class Skype : INetwork, ISharer
    {
        private SKYPE4COMLib.Skype _skype;

        public void Auth()
        {
           // Connecting.BeginInvoke((Action)(() => OnConnecting()));
            OnConnecting();
            _skype = new SKYPE4COMLib.Skype();
            _skype.Attach(5, true);

            if (GetLoginStatus()) OnConnected(_skype.CurrentUser.DisplayName);
        }

        public bool GetLoginStatus()
        {
            // неоднозначность между эвентом и перечислением. Вы, м*ять, серьёзно? 
            
            //return (_skype.AttachmentStatus) == TAttachmentStatus.apiAttachSuccess;
            return true;
        }

        public string GetStatus()
        {
            return _skype.CurrentUser.MoodText;
        }

        public void SetStatus(string status)
        {
            _skype.CurrentUserProfile.MoodText = status;
        }

        public void Deauth()
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public string GetNetworkName()
        {
            return "Skype";
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

        public void Share(string id, string message)
        {
            _skype.SendMessage(id, message);
        }

        public List<Friend> GetFriends()
        {
            List<Friend> tmpList = new List<Friend>();
            IEnumerable<SKYPE4COMLib.User> tmpFriends = _skype.Friends.OfType<SKYPE4COMLib.User>();

            foreach (User friend in tmpFriends)
            {
                // В некоторых случаях, фулл нэйм пустое, а заполнять чем-то надо
                string tmpFullname;
                tmpFullname = String.IsNullOrEmpty(friend.FullName) ? friend.Handle : friend.FullName;

                tmpList.Add(new Friend(friend.Handle, tmpFullname));
            }

            return tmpList;
        }
    }
}
