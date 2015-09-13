using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// Типы обложек
        /// </summary>
        public enum CoverTypes
        {
            None,
            Track,
            Album,
            Artist,
        }

        [DefaultValue(CoverTypes.None)]
        public CoverTypes FoundCoverType { get; private set; }

        /// <summary>
        /// Делает попытку поиска обложки на LastFM
        /// </summary>
        /// <param name="song">Песня, обложку которой будем искать</param>
        /// <returns>True: Обложка найдена</returns>
        public bool FindCover(Song song)
        {
            FoundCoverType = CoverTypes.None;
            Cover.CoverSizes covers = new Cover.CoverSizes();

            //Когда-нибудь я это отрефакторю (или кто-нибудь другой)

            // Получаем инфу о треке, от самой специфичной (для композиции) до самой обобщенной (для артиста)
            // и как только инфа содержит нужную по размерам обложку — прекращаем поиск
            if (!String.IsNullOrEmpty((covers = TrackGetInfo(song.Artist, song.Name).Covers).Large))
            {
                FoundCoverType = CoverTypes.Track;
            }
            else if (!String.IsNullOrEmpty((covers = AlbumGetInfo(song.Artist, song.Album).Covers).Large))
            {
                FoundCoverType = CoverTypes.Album;
            }
            else if (!String.IsNullOrEmpty((covers = ArtistGetInfo(song.Artist).Covers).Large))
            {
                FoundCoverType = CoverTypes.Artist;
            }

            // если нашли хоть одну обложку, то скачиваем и изменяем соответсвующую переменную
            if (FoundCoverType != CoverTypes.None)
            {
                DownloadCover(covers.Large, GetPathFromCoverType(FoundCoverType));
                _isFound = true;
            }

            return _isFound;
        }

        /// <summary>
        /// Возвращает True, если обложка была найдена
        /// </summary>
        /// <returns>True: Обложка найдена, False: Обложка не найдена</returns>
        public bool IsFound()
        {
            return _isFound;
        }


        /// <summary>
        /// Скачивает обложку по указанному Url в указанную папку
        /// </summary>
        /// <param name="imageUrl">Адрес обложки</param>
        /// <param name="pathToDownload">Путь для сохранения обложки, включая название файла</param>
        private void DownloadCover(string imageUrl, string pathToDownload)
        {
            if (String.IsNullOrEmpty(imageUrl)) return;

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(imageUrl, pathToDownload);
            }

            _imagePath = pathToDownload;
        }


        /// <summary>
        /// Возвращает сгенерированный путь для сохранения обложки, в зависимости от
        /// её типа
        /// </summary>
        /// <param name="coverType">Тип обложки</param>
        /// <returns>Путь для сохранения</returns>
        private string GetPathFromCoverType(CoverTypes coverType)
        {
            return String.Concat(Environment.CurrentDirectory, String.Format(@"\{0}Cover.jpg", coverType.ToString()));
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

        //13.09.15: Ай-яй-яй, Влад, прочитал же в книжке, что избыточность — зло.


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

        private Album AlbumGetInfo(string artist, string album)
        {
            const string method = "album.getInfo";

            string resp = APIRequest(method, new Dictionary<string, string>() {{"artist", artist}, {"album", album}});

            var o = JToken.Parse(resp);

            Album art = new Album()
            {
                Id = (int?)o.SelectToken("track.id"),
                Artist = (string)o.SelectToken("album.artist"),
                Name = (string)o.SelectToken("album.name"),
                Url = (string)o.SelectToken("album.url"),
                Covers = new Cover.CoverSizes()
                {
                    Small = (string)o.SelectToken("album.image[0].#text"),
                    Medium = (string)o.SelectToken("album.image[1].#text"),
                    Large = (string)o.SelectToken("album.image[2].#text"),
                }
            };

            return art;
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
