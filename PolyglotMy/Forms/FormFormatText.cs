using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PolyglotMy
{
    public partial class FormFormatText : Form
    {
        int index = 0;
        private TextForBoxes  TextBoxes = new TextForBoxes();
        private string fileName;


        private Form formBefore = null;
        public FormFormatText()
        {
            InitializeComponent();
        }

        public FormFormatText(Form formBefore)
        {
            InitializeComponent();
            this.formBefore = formBefore;
            LoadTexts();
        }

        private void LoadTexts()
        {
            List<Text> list = new List<Text>();
            foreach (var item in Form1.allTexts.NameandFile.ToList())
            {
                list.Add(new Text(item.Value, item.Key));
            }


            cmbTextes.DataSource = list;
            cmbTextes.ValueMember = "File";
            cmbTextes.SelectedIndexChanged += cmbTextes_SelectedIndexChanged;
            cmbTextes.DisplayMember = "Name";
        }
        private void ChangeText()
        {
            TextForBoxes textForBoxes = TextForBoxes.GetTexts(cmbTextes.SelectedValue.ToString());
            // var TextWithoutDivideSymbols = textForBoxes.GetRealTextDivideTextByPhrase();
            TextBoxes = textForBoxes;
            richTextBoxTranslate.Text = TextBoxes.Translate;

            richTextBoxOriginal.Text = TextBoxes.Original;

            richTextBoxLiteralTranslate.Text = TextBoxes.LiteralTranslate;

            richTextBoxNameText.Text = cmbTextes.SelectedText;

            index = cmbTextes.SelectedIndex;
        }
        private void cmbTextes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AnaliseInfo();
                if(IsTextChanged())
                {
                    DialogResult result = MessageBox.Show("Сохранить изменения?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Сохранено", "TsManager"); // Выводим сообщение о звершении.
                        SaveInfo();
                        ChangeText();
                    }
                    else if (result == DialogResult.No)
                    {
                        cmbTextes.SelectedIndexChanged -= cmbTextes_SelectedIndexChanged;
                        cmbTextes.SelectedIndex = index;
                        cmbTextes.SelectedIndexChanged += cmbTextes_SelectedIndexChanged;
                    }
                }
                else
                {
                    ChangeText();
                }             
            }
            catch (Exception ex)
            {
                
                cmbTextes.SelectedIndexChanged -= cmbTextes_SelectedIndexChanged;
                cmbTextes.SelectedIndex = index;
                cmbTextes.SelectedIndexChanged += cmbTextes_SelectedIndexChanged;
                MessageBox.Show(Form1.Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                 
        }

        private bool IsTextChanged()
        {
            if (TextBoxes.Original != richTextBoxOriginal.Text) return true;
            if (TextBoxes.LiteralTranslate != richTextBoxLiteralTranslate.Text) return true;
            if (TextBoxes.Translate != richTextBoxTranslate.Text) return true;
            if (TextBoxes.NameText != richTextBoxNameText.Text) return true;
            return false;
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
            TextBoxes.Original = richTextBoxOriginal.Text;
            TextBoxes.Translate = richTextBoxTranslate.Text;
            TextBoxes.LiteralTranslate = richTextBoxLiteralTranslate.Text;
            TextBoxes.NameText = richTextBoxNameText.Text;

            string filename = TextBoxes.Save(fileName);

            Form1.allTexts.NameandFile.Remove(fileName);
            Form1.allTexts.Add(filename, TextBoxes.NameText);
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

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            FormAddText formAddText = new FormAddText(this);
            formAddText.Show();
            this.Hide();
        }
    }
}
