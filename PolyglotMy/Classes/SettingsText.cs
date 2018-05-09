using System.IO;
using System.Xml.Serialization;


namespace PolyglotMy
{
    public class SettingsText
    {
        public int TextColor { get; set; }
        public int BackColor { get; set; }
        public BoxFont TextFont { get; set; }

        public static SettingsText GetSettings()
        {
            SettingsText settingstext = null;
            string filename = Globals.SettingsFileText;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(SettingsText));
                    settingstext = (SettingsText)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else settingstext = new SettingsText();
            return settingstext;
        }
        public void Save()
        {
            string filename = Globals.SettingsFileText;

            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(SettingsText));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }
    }
}

