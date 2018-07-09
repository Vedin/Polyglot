using System.IO;
using System.Xml.Serialization;

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
        public int forecolor { get; set; }
        public int backcolor { get; set; }
        public BoxFont TextFont { get; set; }

    }
}
