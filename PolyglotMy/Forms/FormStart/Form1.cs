using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
namespace PolyglotMy
{

    partial class Form1 : Form
    {
        public static AllTexts allTexts = AllTexts.GetAllTexts();
        #region Private members

        List<Voice> Voices = new List<Voice>();
        //Ридер бокса
        private SpeechSynthesizer ReaderOriginal = new SpeechSynthesizer();//Ридер оригинала

        private int countChangesTextesList = 0;
        private object _Lock = new object();

        //Для отслеживания изменения настроек
        private SettingsChanged settings = SettingsChanged.None;

        //Settings Members
        SettingsEqualizer _settingsEqualizer = null;
        SettingsText _settingsText = null;

        #endregion

        public static string Massage(Exception ex)
        {
            return ex.Message + ex.Source;
        }

        public Form1()
        {
            InitializeComponent();
            ReaderOriginal.GetInstalledVoices().ToList().ForEach(v => Voices.Add(new Voice() { Name = v.VoiceInfo.Name, InstalledVoice = v }));
            allTexts = AllTexts.GetAllTexts();
            LoadComboBox();
            cmbTextes.SelectedIndex = 0;
        }

        private void LoadComboBox()
        {
            List<Text> list = new List<Text>();
            foreach (var item in allTexts.NameandFile.ToList())
            {
                list.Add(new Text(item.Value, item.Key));
            }


            cmbTextes.DataSource = list;
            cmbTextes.ValueMember = "File";
            cmbTextes.DisplayMember = "Name";
        }

        #region Menu File

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Будет необходимо вызвать метод save но в качестве параметра передавать путь к файлу 
            //изменть єто нужно будет и в Settigns.cs перезгрузить метод
            /*string textAll = richTextBox1.Text + "###" + richTextBoxWordTranslation.Text + "###" + richTextBoxOriginal.Text;
            SaveFileDialog sf = new SaveFileDialog();
            Stream mSt;
            sf.Filter = "Polyglot (*.pol)|*.pol|All files (*.*)|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sf.FileName))
                    sw.WriteLine(textAll);
            } */
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textAll = "";
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Polyglot (*.pol)|*.pol|All files (*.*)|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sw = new StreamReader(of.FileName))
                    textAll = sw.ReadToEnd();
                string[] t3 = Regex.Split(textAll, @"###");
                richTextBoxOriginal.Text = t3[0];
                richTextBoxLiteralTranslate.Text = t3[1];
                richTextBoxTranslate.Text = t3[2];
            }
        }

        #endregion


        #region Buttons for Reader

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultFieldsForSelectionText();
                AllReadersSpeakAsynk();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReaderOriginal.State == SynthesizerState.Speaking)
                {
                    AllReadersPause();
                }
                else
                if (ReaderOriginal.State == SynthesizerState.Paused)
                {
                    AllReadersResume();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            setStop();
            DefaultFieldsForSelectionText();
        }

        #endregion

        #region Open Setting Forms

        //запуск формы для настроек текста 
        private void OpenFormSettingsText(object sender, EventArgs e)
        {
            try
            {
                setStop();
                FormSettingsText Fset = new FormSettingsText(this);
                Fset.Show();
                this.Hide();
                settings = SettingsChanged.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //запуск формы для настроек эквалайзера
        private void OpenFormSettingsEquilezer(object sender, EventArgs e)
        {
            try
            {
                setStop();
                FormSettingsEqualizer Fset = new FormSettingsEqualizer(this);
                Fset.Show();
                this.Hide();
                settings = SettingsChanged.Equlizer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Others

        //запускаеться при нажатии button Play
        private void setStopPauseEnabled()
        {

            if (!string.IsNullOrEmpty(richTextBoxTranslate.Text)
                || !string.IsNullOrEmpty(richTextBoxLiteralTranslate.Text)
                || !string.IsNullOrEmpty(richTextBoxOriginal.Text))
            {
                buttonPause.Enabled = true;
                buttonStop.Enabled = true;
            }
            else
            {
                buttonPause.Enabled = false;
                buttonStop.Enabled = false;
            }
        }

        private void setStop()
        {
            try
            {
                buttonPause.Enabled = false;
                buttonStop.Enabled = false;
                AllReadersDispose();
                buttonPlay.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void RichTextBoxTranslate_TextChanged(object sender, EventArgs e)
        {
            char[] sentenceSymbols = { '.', '?', '!' };
            const string pattern = @"[aeyuio]";
            var regex = new Regex(pattern);

            string s = "";
            int words = 0;
            int sentences = 0;
            int syllables = 0;

            s = richTextBoxTranslate.Text;
            words += s.Split(' ').Length;
            sentences += s.Split(sentenceSymbols).Length;
            syllables += regex.Matches(s).Count;
            label2.Text = Math.Round(FlaschScore(words, sentences, syllables)).ToString();
        }


        private void AddTextToLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddText formAddText = new FormAddText(this);
            formAddText.Show();
            this.Hide();
            settings = SettingsChanged.None;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            allTexts.Save();
        }

        private void cmbTextes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (countChangesTextesList >= 2)
            {
                LoaderSettiingsForAllTextBox();
            }
            else
            {
                countChangesTextesList++;
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
