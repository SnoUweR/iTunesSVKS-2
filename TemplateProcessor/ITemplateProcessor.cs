using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.TemplateProcessor
{
    interface ITemplateProcessor
    {
        string ProcessTemplate(string template, Song currentSong);
    }
}
