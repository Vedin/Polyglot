using System.IO;
using System.Xml.Serialization;

namespace PolyglotMy
{
    public class SettingsEqualizer
    {
        public int SliderLeft { get; set; }
        public int SliderRight { get; set; }
        public int SliderMid { get; set; }
        public int Volume { get; set; }
        public int Speed { get; set; }
        public static SettingsEqualizer GetSettings()
        {
            SettingsEqualizer formsett = null;
            string filename = Globals.SettingsFileEqulizer;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(SettingsEqualizer));
                    formsett = (SettingsEqualizer)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else formsett = new SettingsEqualizer();
            return formsett;
        }
        public void Save()
        {
            string filename = Globals.SettingsFileEqulizer;

            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(SettingsEqualizer));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }
    }
}
