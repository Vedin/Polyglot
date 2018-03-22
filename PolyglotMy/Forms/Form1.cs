using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Text.RegularExpressions;

namespace PolyglotMy
{
    public partial class Form1 : Form
    {
        /*
         * Нужно будет удалить проверку на доступные голоса
         * Исправить ошибку что возоможно добавить только один голос (Microsoft Anna)
          
         * Добавить коментарии описывающие все 
         * 
         */
        #region Private members

        private SpeechSynthesizer ssO;
        private SpeechSynthesizer ss = new SpeechSynthesizer();
        int lwst = 0;

        private SpeechSynthesizer Reader = new SpeechSynthesizer();//Ридер оригинала
        private object _Lock = new object();

        #endregion

        


       
        public Form1()
        {
            InitializeComponent();

            #region Old Code 
            //созание ридера
            ssO = new SpeechSynthesizer();
            ssO.Volume = 2;
            ssO.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgressO);
            ssO.Rate = 2;
            ss = new SpeechSynthesizer();
            //-ss.Volume = 100;// от 0 до 100
            //ss.Rate = trackBarSpeed.Value;//от -10 до 10
            ss.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);
            #endregion//

            #region Проверка на доступные Голоса
            List<Voice> Voices = new List<Voice>();
            Reader.GetInstalledVoices().ToList().ForEach(v => Voices.Add(new Voice() { Name = v.VoiceInfo.Name, InstalledVoice = v }));

            foreach (var voice in Voices)
            {
                richTextBox1.Text += voice.Name + new string(' ', 30)/* + voice.InstalledVoice + new string('-',10) + '\n'*/;
            }
            #endregion

        }

        #region Как я понял для рисовки( я єто даже не трогал)

        private void SelColor(int start_pos)
        {
            int j = 0;
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionStart = start_pos;
            j = richTextBox1.Text.IndexOf(' ', start_pos);
            int j1 = richTextBox1.Text.IndexOf('\n', start_pos);
            if (j1 >= richTextBox1.Text.Length || j1 < 0) j1 = richTextBox1.Text.Length;
            if (j >= richTextBox1.Text.Length || j < 0) j = richTextBox1.Text.Length;
            j = Math.Min(j1, j);
            richTextBox1.SelectionLength = j - start_pos;
            richTextBox1.SelectionColor = Color.Blue;
        }
        private void SetColorO(int start_pos)
        {
            int j = 0;
            richTextBoxOriginal.SelectionColor = Color.Black;
            richTextBoxOriginal.SelectionStart = start_pos;
            j = richTextBoxOriginal.Text.IndexOf(' ', start_pos);
            int j1 = richTextBoxOriginal.Text.IndexOf('\n', start_pos);
            if (j1 >= richTextBoxOriginal.Text.Length || j1 < 0) j1 = richTextBoxOriginal.Text.Length;
            if (j >= richTextBoxOriginal.Text.Length || j < 0) j = richTextBoxOriginal.Text.Length;
            j = Math.Min(j1, j);
            richTextBoxOriginal.SelectionLength = j - start_pos;
            richTextBoxOriginal.SelectionColor = Color.Blue;
        }
        private void SetColorWT(bool article)
        {
            int j = 0;
            richTextBoxWordTranslation.SelectionColor = Color.Black;
            richTextBoxWordTranslation.SelectionStart = lwst;
            j = richTextBoxWordTranslation.Text.IndexOf(' ', lwst);
            int j1 = richTextBoxWordTranslation.Text.IndexOf('\n', lwst);

            if (j1 >= richTextBoxWordTranslation.Text.Length || j1 < 0) j1 = richTextBoxWordTranslation.Text.Length;
            if (j >= richTextBoxWordTranslation.Text.Length || j < 0) j = richTextBoxWordTranslation.Text.Length;
            j = Math.Min(j1, j);
            //if (article) j= richTextBoxWordTranslation.Text.IndexOf(' ', j + 1);
            richTextBoxWordTranslation.SelectionLength = j - lwst;
            richTextBoxWordTranslation.SelectionColor = Color.Blue;
            /*richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.SelectionColor = Color.Black;*/
            //ss.Pause();
            if (!article) lwst = j + 1;
        }
        private void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)//Это не мое не трогаю
        {
            if (e.Text == "The" || e.Text == "the" || e.Text == "A" || e.Text == "a" || e.Text == "to" || e.Text == "of") return;
            else SetColorWT(false);
            SelColor(e.CharacterPosition);
            //Console.WriteLine("Current word being spoken: " + e.Text);
        }
        private void synth_SpeakProgressO(object sender, SpeakProgressEventArgs e)//Это не мое не трогаю
        {
            SetColorO(e.CharacterPosition);
            //Console.WriteLine("Current word being spoken: " + e.Text);
        }

        #endregion

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
                richTextBox1.Text = t3[0];
                richTextBoxWordTranslation.Text = t3[1];
                richTextBoxOriginal.Text = t3[2];
            }
        }

        #endregion

        #region Buttons for Reader

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            #region Old Code
            /*
             ss.SpeakAsyncCancelAll();
             ssO.SpeakAsyncCancelAll();
             lwst =0;

             richTextBox1.SelectionColor = Color.Black;
                 richTextBox1.SelectionStart = 0;
                 richTextBox1.SelectionLength = 0;
                 buttonPlay.Enabled = false;
 /*            ss.Volume = trackBarVolume.Value;
             ss.Rate = trackBarSpeed.Value;
             ssO.Rate = Math.Min(trackBarSpeed.Value + 2,10);
                 ssO.SpeakAsync(richTextBoxOriginal.Text);
                 ss.SpeakAsync(richTextBox1.Text);
                 buttonPlay.Enabled = true;
           */
            #endregion
            try
            {
                if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
                {
                    setStopPauseEnabled();

                    Reader = new SpeechSynthesizer();
                    Reader.SelectVoice("Microsoft Server Speech Text to Speech Voice (en-AU, Hayley)");

                    Reader.SpeakAsync(richTextBoxOriginal.Text);
                    buttonPlay.Enabled = false;
                    Reader.SpeakCompleted += Reader_SpeakCompleted;                   
                }
                else
                {
                    MessageBox.Show("Type the text that needs to be told", Globals.INF, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (Reader.State == SynthesizerState.Speaking)
                {
                    Reader.Pause();

                }
                else
                    if (Reader.State == SynthesizerState.Paused)
                {
                    Reader.Resume();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region Old Code
            /*
            if (ss.State.ToString() == "Paused")
            {
                ss.Resume();
                ssO.Resume();
            }
            else
            {
                ss.Pause();
                ssO.Pause();
            }*/
            #endregion

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            setStop();
        }

        #endregion

        #region Open Setting Forms

        //запуск формы для настроек текста 
        private void тектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reader.Dispose();
            try
            {
                buttonPause.Enabled = false;
                buttonStop.Enabled = false;                
                buttonPlay.Enabled = true;
                Reader.Dispose();
                FormSettingsText Fset = new FormSettingsText(this);
                Fset.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //запуск формы для настроек эквалайзера
        private void еквалайзерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reader.Dispose();
            try
            {
                buttonPause.Enabled = false;
                buttonStop.Enabled = false;
                buttonPlay.Enabled = true;
                Reader.Dispose();
                FormSettingsEqualizer Fset = new FormSettingsEqualizer(this);
                Fset.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Others

        //запускаеться при нажатии button Play
        private void setStopPauseEnabled()
        {
            if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
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

        void Reader_SpeakCompleted(object sender, System.Speech.Synthesis.SpeakCompletedEventArgs e)
        {
            try
            {
                buttonPlay.Enabled = true;
                setStopPauseEnabled();
                Reader.SpeakCompleted -= Reader_SpeakCompleted;
                Reader.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }

        }

        private void setStop()
        {
            try
            {
                buttonPause.Enabled = false;
                buttonStop.Enabled = false;
                Reader.Dispose();
                buttonPlay.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
