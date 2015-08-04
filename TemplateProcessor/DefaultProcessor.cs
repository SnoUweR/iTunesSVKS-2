using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.TemplateProcessor
{
    class DefaultProcessor : ITemplateProcessor
    {
        /* 
            {name} - Название песни
            {artist} - Исполнитель песни
            {playlist} - Плейлист
            {album} - Альбом
            {count} - Количество исполнений
            {genre} - Жанр
         */

        public string ProcessTemplate(string template, Song currentSong)
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>(6)
            {
                {"{name}", currentSong.Name},
                {"{artist}", currentSong.Artist},
                {"{playlist}", currentSong.Playlist},
                {"{album}", currentSong.Album},
                {"{count}", currentSong.Count.ToString()},
                {"{genre}", currentSong.Genre},
            };

            return TextReplacer.DictonaryReplace(template, replaceDict);
        }
    }
}
