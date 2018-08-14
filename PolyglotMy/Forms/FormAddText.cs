using System;
using System.Windows.Forms;

namespace PolyglotMy
{
    public partial class FormAddText : Form
    {
        private TextForBoxes  text = new TextForBoxes();

        private Form formBefore = null;
        public FormAddText()
        {
            InitializeComponent();
        }

        public FormAddText(Form formBefore)
        {
            InitializeComponent();
            this.formBefore = formBefore;
        }

        private void AnaliseInfo()
        {
            if(String.IsNullOrEmpty(richTextBoxOriginal.Text))
            {
                throw new Exception("Origainal text must be filled");
            }
            if (String.IsNullOrEmpty(richTextBoxLiteralTranslate.Text))
            {
                throw new Exception("LiteralTranslate text must be filled");
            }
            if (String.IsNullOrEmpty(richTextBoxTranslate.Text))
            {
                throw new Exception("Translate text must be filled");
            }
            if (String.IsNullOrEmpty(richTextBoxNameText.Text))
            {
                throw new Exception("Name must be filled");
            }

            int lengthOriginalPrases = richTextBoxOriginal.Text.Split(Form1.splitPrases, options: StringSplitOptions.RemoveEmptyEntries).Length;
            int lengthLiteralTranslatePrases = richTextBoxLiteralTranslate.Text.Split(Form1.splitPrases, options: StringSplitOptions.RemoveEmptyEntries).Length;
            if(lengthOriginalPrases != lengthLiteralTranslatePrases)
            {
                throw new Exception(string.Format("Phrases must be the same number\n OriginalPrases = {0}" +
                    " \nLiteralTranslatePrases = {1}", 
                    lengthOriginalPrases,
                    lengthLiteralTranslatePrases));
            }
            
            int lengthOriginalSentences = richTextBoxOriginal.Text.Split(Form1.splitSentenceSymbols).Length;
            int lengthLiteralTranslateSentences = richTextBoxLiteralTranslate.Text.Split(Form1.splitSentenceSymbols).Length;
            int lengthTranslateSentences = richTextBoxTranslate.Text.Split(Form1.splitSentenceSymbols).Length;
            if(!(lengthOriginalSentences == lengthTranslateSentences && lengthOriginalSentences==lengthLiteralTranslateSentences))
            {
                throw new Exception(
                    string.Format(
                        "Sentences must be the same number\n OriginalSentences = {0}\nLiteralTranslateSentences = {1}" +
                        "\nLiteralTranslateSentences = {2}",
                        lengthOriginalSentences,
                        lengthLiteralTranslateSentences,
                        lengthTranslateSentences)
                        );
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                AnaliseInfo();
                SaveInfo();
                CleanBoxes();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Form1.Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveInfo()
        {
            text.Original = richTextBoxOriginal.Text;
            text.Translate = richTextBoxTranslate.Text;
            text.TranslateOur = richTextBoxLiteralTranslate.Text;
            text.NameText = richTextBoxNameText.Text;

            string filename = text.Save();

            Form1.allTexts.NameandFile.Add(filename, text.NameText);
        }

        private void CleanBoxes()
        {
            richTextBoxNameText.Text = "";
            richTextBoxOriginal.Text = "";
            richTextBoxTranslate.Text = "";
            richTextBoxLiteralTranslate.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CleanBoxes();          
        }

        private void FormAddText_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(this.formBefore is null)) this.formBefore.Show();
        }
    }
}
