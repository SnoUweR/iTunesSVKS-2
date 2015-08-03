using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesLib;

namespace iTunesSVKS_2
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

        public Song()
        {
            
        }
    }
}
