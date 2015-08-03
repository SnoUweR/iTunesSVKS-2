using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesSVKS_2.TemplateProcessor
{
    static class TextReplacer
    {
        /// <summary>
        /// Заменяет слова, соответствующие ключам из словаря, на значения элементов с этими ключами
        /// </summary>
        /// <param name="text">Текст для обработки</param>
        /// <param name="dict">Словрь (Key - Слово, которое нужно заменить | Value - На что нужно заменить)</param>
        /// <returns></returns>
        public static string DictonaryReplace(string text, Dictionary<string, string> dict)
        {
            string tmpText = text;
            foreach (string textToReplace in dict.Keys)
            {
                tmpText = tmpText.Replace(textToReplace, dict[textToReplace]);
            }
            return tmpText;
        }
    }
}
