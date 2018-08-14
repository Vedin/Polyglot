using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolyglotMy
{
    class Text
    {
        public string Name { get; set; }
        public string File { get; set; }

        public Text(string Name, string File)
        {
            this.Name = Name;
            this.File = File;
        }
    }
}
