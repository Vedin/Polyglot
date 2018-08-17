using System;
using System.Drawing;
using System.Windows.Forms;

namespace PolyglotMy
{
    partial class Form1 : Form
    {
        private string[] textForBoxesChanged = new string[3];

        private string[] text = new string[3];
        private void TextBoxLoadSettings(RichTextBox box, bool isDefault = false)
        {
            if (isDefault)
            {
               
            }
            else
            {
                box.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
                box.SelectionColor = Color.FromArgb(_settingsText.TextColor);
                box.Font = _settingsText.TextFont.GetFont();
            }
        }

        private void LoaderSettiingsForAllTextBox()
        {
            try
            {
                _settingsText = SettingsText.GetSettings(); //Десериализация
                try
                {
                    LoadTextToTextBoxes();
                    richTextBoxTranslate.SelectAll();
                    richTextBoxOriginal.SelectAll();
                    richTextBoxLiteralTranslate.SelectAll();

                    TextBoxLoadSettings(richTextBoxTranslate);
                    TextBoxLoadSettings(richTextBoxOriginal);
                    TextBoxLoadSettings(richTextBoxLiteralTranslate);
                    

                    richTextBoxTranslate.Select(0, 0);
                    richTextBoxOriginal.Select(0, 0);
                    richTextBoxLiteralTranslate.Select(0, 0);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTextToTextBoxes()
        {
            TextForBoxes textForBoxes = TextForBoxes.GetTexts(cmbTextes.SelectedValue.ToString());
            text[0] = textForBoxes.Original;
            text[1] = textForBoxes.LiteralTranslate;
            text[2] = textForBoxes.Translate;


            /*text[0] = "The Parties ###|### to this ###|### Treaty ###|### reaffirm ###|### their faith ###|### in the purposes ###|### and principles ###|### " +
                "of the Charter ###|### of the United Nations ###|###and their desire ###|###to live in peace###|### with all peoples###|### and all governments.###|###" +
                "\nThey are###|### determined to safeguard ###|###the freedom,###|### common heritage ###|###and civilisation of their peoples,###|### founded on" +
                " the principles of democracy, individual liberty and the rule of law.";

            text[1] = "Сторони ###|### цей###|### Договір ###|### знову  підтверджувати ###|### їх віра ###|### в цілі ###|### та принципи###|### Хартія ###|### " +
                "Об’єднаний Нації ###|###та їх бажання###|### жити у мир###|### з усі народи###|### та усі уряди.###|###" +
                "\nВони є ###|###визначений охороняти ###|###свободу, ###|###спільний спадщина ###|###та цивілізація їх народи,###|###" +
                " заснований на принципи демократія, індивідуальний свобода та правило закон.";

            text[2] = "Сторони цей Договір знову підтверджувати їх віра в цілі та принципи Хартія " +
                "Об’єднаний Нації та їх бажання жити у мир з усі народи та усі уряди." +
                "\nВони є визначений охороняти свободу, спільний спадщина та цивілізація їх народи," +
                " заснований на принципи демократія, індивідуальний свобода та правило закон.";*/

            GetRealTextDivideTextByPhrase();

            

            richTextBoxTranslate.Text = textForBoxesChanged[2];

            richTextBoxOriginal.Text = textForBoxesChanged[0];

            richTextBoxLiteralTranslate.Text = textForBoxesChanged[1];
        }
    }
}
