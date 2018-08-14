using System.IO;
using System;
using System.Xml.Serialization;

namespace PolyglotMy
{
    public class TextForBoxes
    {
        private static readonly Random random = new Random();       

        public string Original { get; set; }
        public string Translate { get; set; }
        public string LiteralTranslate { get; set; }
        public string NameText { get; set; }

        
        public static TextForBoxes GetTexts(string FileName)
        {
            TextForBoxes formsett = null;
            string filename = FileName;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(TextForBoxes));
                    formsett = (TextForBoxes)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else formsett = new TextForBoxes();
            return formsett;
        }

        
        public string Save()
        {
            string folderName = Directory.GetCurrentDirectory();
            string pathString = Path.Combine(folderName, "textfile");
            if(!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }           
            string filename = GetNewFileName();

            filename = Path.Combine(pathString, filename);

            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(TextForBoxes));
                xser.Serialize(fs, this);
                fs.Close();
            }
            return filename;
        }

        private static string GetRandomString(int pwdLength = 9)
        {
            char[] letters = Globals.TextForBoxes.AllowedCharacters.ToCharArray();
            string s = "text";
            for (int i = 0; i < pwdLength; i++)
            {
                s += letters[random.Next(letters.Length)].ToString();
            }
            return s + ".xml";
        }

        private static string GetNewFileName()
        {
            string s = "";
            do
            {
                s = GetRandomString();
            }while (Form1.allTexts.ContainsKey(s));
            return s;
        }


    }
}
