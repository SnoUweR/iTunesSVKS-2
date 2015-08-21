using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks
{
    interface INetwork
    {
        
        /// <summary>
        /// Производит авторизацию в социальной сети
        /// </summary>
        void Auth();

        /// <summary>
        /// Возвращает статус подключения к социальной сети
        /// </summary>
        /// <returns>True: Пользователь авторизирован</returns>
        bool GetLoginStatus();

        /// <summary>
        /// Возвращает текущий статус в профиле пользователя
        /// </summary>
        /// <returns></returns>
        string GetStatus();

        /// <summary>
        /// Задает новый статус в профиль пользователя
        /// </summary>
        /// <param name="status"></param>
        void SetStatus(string status);

        /// <summary>
        /// Производит деавторизацию пользователя в социальной сети 
        /// </summary>
        void Deauth();

        /// <summary>
        /// УНИЧТОЖАЕТ ВСЁ НА СВОЕМ ПУТИ!!!
        /// </summary>
        void Destroy();

        /// <summary>
        /// Возвращает имя социальной сети
        /// </summary>
        /// <returns></returns>
        string GetNetworkName();

        /// <summary>
        /// Данное событие вызывается после успешной авторизации пользователя в социальной сети
        /// </summary>
        event ConnectedEventHandler Connected;

        /// <summary>
        /// Данное событие вызывается при начале соединения и авторизации с социальной сетью
        /// </summary>
        event ConnectingEventHandler Connecting;
    }

    internal delegate void ConnectedEventHandler(object sender, string username);

    internal delegate void ConnectingEventHandler(object sender, string networkName);
}
