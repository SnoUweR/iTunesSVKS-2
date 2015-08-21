using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.Networks.LastFM
{
    class LastFM : ICoverFinder
    {
        private const string APIKey = "e8203c02891d90390e16205aa05c1d6d";
        private bool _isFound = false;
        private string _imagePath;

        /// <summary>
        /// Делает попытку поиска обложки на LastFM
        /// </summary>
        /// <param name="song">Песня, обложку которой будем искать</param>
        /// <returns>True: Обложка найдена</returns>
        public bool FindCover(Song song)
        {
            Track tmpTrack = TrackGetInfo(song.Artist, song.Name);
            Artist tmpArtist;
            
            //Когда-нибудь я это отрефакторю (или кто-нибудь другой)

            if (!String.IsNullOrEmpty(tmpTrack.Covers.Large))
            {
                _imagePath = String.Concat(Environment.CurrentDirectory, @"\TrackCover.jpg");
                DownloadCover(tmpTrack.Covers.Large, _imagePath);
                _isFound = true;
            }
            else if (!String.IsNullOrEmpty((tmpArtist = ArtistGetInfo(song.Artist)).Covers.Large))
            {
                _imagePath = String.Concat(Environment.CurrentDirectory, @"\ArtistCover.jpg");
                DownloadCover(tmpArtist.Covers.Large, _imagePath);
                _isFound = true;
            }

            return _isFound;
        }

        public bool IsFound()
        {
            return _isFound;
        }

        private void DownloadCover(string imageUrl, string pathToDownload)
        {
            if (String.IsNullOrEmpty(imageUrl)) return;
            WebClient webClient = new WebClient();
            webClient.DownloadFile(imageUrl, pathToDownload);
        }

        public Image GetCoverImage()
        {
            if (_isFound)
            {
               return Image.FromFile(_imagePath);
            }
            return null;
        }

        public string GetImagePath()
        {
            if (_isFound)
            {
                return _imagePath;
            }
            return null;
        }

        // Вообще, думаю это всё нехило сломается, если API изменят

        // Так как в данный момент используется только обложка, то тут небольшой избыток получаемой с API инфы
        // В песпективе, из этого всего можно сделать аналог ластфмовского скробллера


        /// <summary>
        /// Возвращает объект, представляющий текущую песню, прослушиваемую пользователем.
        /// Либо null, если ничего не слушает.
        /// Либо вообще вылетает, ибо я не могу в тестинг
        /// </summary>
        /// <param name="user">Имя пользователя</param>
        /// <returns>Текущая прослушиваемая песня, либо null - если её нет</returns>
        private Track UserGetCurrentTrack(string user)
        {
            const string method = "user.getrecenttracks";

            string resp = APIRequest(method, new Dictionary<string, string>() { { "user", user } });

            var o = JToken.Parse(resp);

            bool isAnythingPlayed = (bool)o.SelectToken("recenttracks.track[0].@attr.nowplaying");

            if (isAnythingPlayed)
            {
                return TrackGetInfo((string)o.SelectToken("recenttracks.track[0].artist.#text"),
                    (string)o.SelectToken("recenttracks.track[0].name"));
            }

            return null;
        }

        private Track TrackGetInfo(string artist, string name)
        {
            const string method = "track.getInfo";

            string resp = APIRequest(method, new Dictionary<string, string>() { { "artist", artist }, {"track", name} });

            var o = JToken.Parse(resp);

            Track track = new Track()
            {
                Id = (int?)o.SelectToken("track.id"),
                Listeners = (int)o.SelectToken("track.listeners"),
                Name = (string)o.SelectToken("track.name"),
                Artist = (string)o.SelectToken("track.artist.name"),
                TopTag = (string)o.SelectToken("track.toptags.tag[0].name"),
                Album = (string)o.SelectToken("track.album.title"),
                Playcount = (int)o.SelectToken("track.playcount"),
                Url = (string)o.SelectToken("track.url"),
                Covers = new Cover.CoverSizes()
                {
                    Small = (string)o.SelectToken("track.album.image[0].#text"),
                    Medium = (string)o.SelectToken("track.album.image[1].#text"),
                    Large = (string)o.SelectToken("track.album.image[2].#text"),
                    Extralarge = (string)o.SelectToken("artist.image[3].#text"),
                }
            };

            return track;
        }

        private Artist ArtistGetInfo(string artist)
        {
            const string method = "artist.getInfo";

            string resp = APIRequest(method, new Dictionary<string, string>() {{"artist", artist}});

            var o = JToken.Parse(resp);

            Artist art = new Artist()
            {
                Listeners = (int)o.SelectToken("artist.stats.listeners"),
                Name = (string)o.SelectToken("artist.name"),
                Playcount = (int)o.SelectToken("artist.stats.playcount"),
                Url = (string)o.SelectToken("artist.url"),
                Covers = new Cover.CoverSizes()
                {
                    Small = (string)o.SelectToken("artist.image[0].#text"),
                    Medium = (string)o.SelectToken("artist.image[1].#text"),
                    Large = (string)o.SelectToken("artist.image[2].#text"),
                    Extralarge = (string)o.SelectToken("artist.image[3].#text"),
                    Mega = (string)o.SelectToken("artist.image[4].#text"),
                }
            };

            return art;
        }

        /// <summary>
        /// Выполняет запрос к LastFM API и возвращает ответ в JSON
        /// </summary>
        /// <param name="method">Имя API-метода</param>
        /// <param name="apiParams">Словарь параметров</param>
        /// <returns>Ответ сервера в JSON</returns>
        private string APIRequest(string method, Dictionary<string, string> apiParams)
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("http://ws.audioscrobbler.com/2.0/");
            buff.Append("?method=");
            buff.Append(method);
            buff.Append("&api_key=");
            buff.Append(APIKey);

            foreach (KeyValuePair<string, string> param in apiParams)
            {
                buff.Append(String.Format("&{0}={1}", param.Key, param.Value));
            }

            buff.Append("&format=");
            buff.Append("json");

            Uri url = new Uri(buff.ToString());


            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();

            string imageUrl = String.Empty;
            string tokenResult = new StreamReader(tokenResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();

            return tokenResult;
        }
    }
}
