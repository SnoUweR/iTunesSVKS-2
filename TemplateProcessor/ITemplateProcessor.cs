using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2.TemplateProcessor
{
    interface ITemplateProcessor
    {
        string ProcessTemplate(string template, Song currentSong);
    }
}
