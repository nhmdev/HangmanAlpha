using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlpha
{
    class Files
    {
        public static string PathToText
        {
            get
            {
                String strAppDir = Path.GetDirectoryName(
                            Assembly.GetExecutingAssembly().GetName().CodeBase);
                //String strFullPathToMyFile = Path.Combine(strAppDir, "\\Text\\MenuGFX.txt");
                return strAppDir;
            }
            set { }
        }
    }
}
