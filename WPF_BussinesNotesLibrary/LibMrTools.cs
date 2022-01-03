using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BussinesNotesLibrary.Models;

namespace WPF_BussinesNotesLibrary
{
    public class LibMrTools
    {
        public static string AddStringWithSeparator(char separator, string textPrev, string textAdd)
        {
            string text;
            if (textPrev == null || textPrev == "")
            {
                text = textAdd;
            }
            else
            {
                text = string.Join(separator, new[] { textPrev, textAdd });
            }
            return text;
        }


    }
}
