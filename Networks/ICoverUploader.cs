using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.Networks
{
    interface ICoverUploader
    {
        /// <summary>
        /// Возвращает или задает путь до изображения, которое следует загрузить на сервер
        /// </summary>
        string CoverPath { get; set; }

        /// <summary>
        /// Нужно ли загружать обложки на сервер
        /// </summary>
        bool UploadCover { get; set; }
    }
}
