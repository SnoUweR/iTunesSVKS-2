using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace iTunesSVKS_2.Networks
{
    class LastFM : ICoverFinder
    {
        private const string APIKey = "e8203c02891d90390e16205aa05c1d6d";

        public Image FindCover(Song song)
        {
            ArtistGetInfo(song.Artist);
            return null;
        }

        private void TrackGetInfo(string artist, string name)
        {
            const string method = "track.getInfo";

        }

        private void ArtistGetInfo(string artist)
        {
            const string method = "artist.getInfo";

            string resp = APIRequest(method, new Dictionary<string, string>() {{"artist", artist}});

            Console.WriteLine();
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

            var o = JToken.Parse(tokenResult);


            imageUrl = (string)o.SelectToken("track.album.image[3].#text");
            if (string.IsNullOrEmpty(imageUrl))
            {
                imageUrl = (string)o.SelectToken("artist.image[4].#text");
            }

            return imageUrl;

        }
    }
}
