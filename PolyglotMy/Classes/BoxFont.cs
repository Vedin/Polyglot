using System.Drawing;

namespace PolyglotMy
{
    public class BoxFont
    {
        public string familyName;
        public float emSize;
        public FontStyle style;
        public GraphicsUnit unit;
        public byte gbiCharSet;
        public bool gbiVerticalFont;

        public BoxFont(){}
        public BoxFont(Font font)
        {
            this.familyName = font.FontFamily.Name;
            this.emSize = font.Size;
            this.gbiCharSet = font.GdiCharSet;
            this.gbiVerticalFont = font.GdiVerticalFont;
            this.style = font.Style;
            this.unit = font.Unit;
        }

        public Font GetFont()
        {
            return new Font(this.familyName, this.emSize, this.style, this.unit, this.gbiCharSet, this.gbiVerticalFont);
        }
    }
}
