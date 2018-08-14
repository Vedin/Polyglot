using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using PolyglotMy.Classes;

namespace PolyglotMy
{
    public class AllTexts
    {
        public XmlSerializableDictionary<string,string> NameandFile{ get; set; }
       
        public static AllTexts GetAllTexts()
        {            
            AllTexts formsett = null;
            string filename = Globals.TextForBoxes.AllTexts.FileName;
        if (File.Exists(filename))
        {
                try
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        XmlSerializer xser = new XmlSerializer(typeof(AllTexts));
                        formsett = (AllTexts)xser.Deserialize(fs);
                        fs.Close();
                        return formsett;
                    }
                }
                catch(Exception e)
                {
                  
                }                             
        }
        
            formsett = new AllTexts();
            formsett.NameandFile = new XmlSerializableDictionary<string, string>();
            return formsett;
        }
        public void Save()
        {
            string filename = Globals.TextForBoxes.AllTexts.FileName;

            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(AllTexts));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }
        public void Add(string Key, string Value)
        {
            NameandFile.Add(Key, Value);
        }

        public bool ContainsKey(string Key)
        {
            return NameandFile.ContainsKey(Key);
        }

    }
}

