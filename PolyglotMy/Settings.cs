using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace PolyglotMy
{
    class Settings
    {
        public static Settings GetSettings()
        {
            Settings formsett = null;
            string filename = Globals.SettingsFile;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Settings));
                    fs.Close();
                }
            }
            else formsett = new Settings();
            return formsett;
        }
        public void Save()
        {
            string filename = Globals.SettingsFile;

            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Settings));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }
        public void Save(StreamWriter file_way)
        {

        }
        //txtBox #1 Text Settings
        public int forecolor { get; set; }
       // public FontDialog textfont { get; set;}
        public int backcolor { get; set; }
       /*По компонентное сохранение шрифта крайний случай 
        public byte tfGDI { get; set; }
        public bool tfBold { get; set; }*/
    }
}
