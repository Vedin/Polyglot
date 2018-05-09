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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveInfo();

            CleanBoxes();
        }

        private void SaveInfo()
        {
            text.Original = richTextBoxOriginal.Text;
            text.Translate = richTextBoxTranslate.Text;
            text.TranslateOur = richTextBoxTranslateOur.Text;
            text.NameText = richTextBoxNameText.Text;

            string filename = text.Save();

            Form1.allTexts.NameandFile.Add(filename, text.NameText);
        }

        private void CleanBoxes()
        {
            richTextBoxNameText.Text = "";
            richTextBoxOriginal.Text = "";
            richTextBoxTranslate.Text = "";
            richTextBoxTranslateOur.Text = "";
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
