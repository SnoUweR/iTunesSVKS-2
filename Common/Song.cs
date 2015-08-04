using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using iTunesLib;

namespace iTunesSVKS_2.Common
{
    class Song
    {
        /// <summary>
        /// Исполнитель песни
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Название песни
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Плейлист, откуда песня воспроизводится
        /// </summary>
        public string Playlist { get; set; }

        /// <summary>
        /// Альбом песни
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Жанр песни
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Количество воспроизведений песни
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Обложка песни
        /// </summary>
        public Image Cover { get; set; }

        public Song()
        {
            
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Artist, Name);
        }

        //TODO: Влад, ты — наркоман. Неужели нет более изящного способа?
        public override bool Equals(object obj)
        {
            Song s2 = obj as Song;
            if (s2 == null) return false;
            Song s1 = this;
            return s1.Name == s2.Name && s1.Artist == s2.Artist &&
                   s1.Album == s2.Album && s1.Genre == s2.Genre &&
                   s1.Count == s2.Count && s1.Playlist == s2.Playlist;
        }
    }
}
