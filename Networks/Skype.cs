using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKYPE4COMLib;

namespace iTunesSVKS_2.Networks
{
    class Skype : INetwork
    {
        private SKYPE4COMLib.Skype _skype;

        public void Auth()
        {
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
           
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public event ConnectedEventHandler Connected;

        protected virtual void OnConnected(string username)
        {
            var handler = Connected;
            if (handler != null) handler(this, username);
        }
    }
}
