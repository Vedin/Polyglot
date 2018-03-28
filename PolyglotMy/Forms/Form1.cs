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

        private SpeechSynthesizer ReaderOriginal = new SpeechSynthesizer();//Ридер оригинала
        private SpeechSynthesizer ReaderTranslate = new SpeechSynthesizer();
        private SpeechSynthesizer ReaderTranslateOur = new SpeechSynthesizer();

        private object _Lock = new object();


        //Settings Members
        SettingsEqualizer _settingsequalizer = null;

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
            ReaderOriginal.GetInstalledVoices().ToList().ForEach(v => Voices.Add(new Voice() { Name = v.VoiceInfo.Name, InstalledVoice = v }));

            foreach (var voice in Voices)
            {
                richTextBoxTranslate.Text += voice.Name + new string(' ', 30)/* + voice.InstalledVoice + new string('-',10) + '\n'*/;
            }
            #endregion

        }

        #region Как я понял для рисовки( я єто даже не трогал)

        private void SelColor(int start_pos)
        {
            int j = 0;
            richTextBoxTranslate.SelectionColor = Color.Black;
            richTextBoxTranslate.SelectionStart = start_pos;
            j = richTextBoxTranslate.Text.IndexOf(' ', start_pos);
            int j1 = richTextBoxTranslate.Text.IndexOf('\n', start_pos);
            if (j1 >= richTextBoxTranslate.Text.Length || j1 < 0) j1 = richTextBoxTranslate.Text.Length;
            if (j >= richTextBoxTranslate.Text.Length || j < 0) j = richTextBoxTranslate.Text.Length;
            j = Math.Min(j1, j);
            richTextBoxTranslate.SelectionLength = j - start_pos;
            richTextBoxTranslate.SelectionColor = Color.Blue;
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
            richTextBoxTranslateOur.SelectionColor = Color.Black;
            richTextBoxTranslateOur.SelectionStart = lwst;
            j = richTextBoxTranslateOur.Text.IndexOf(' ', lwst);
            int j1 = richTextBoxTranslateOur.Text.IndexOf('\n', lwst);

            if (j1 >= richTextBoxTranslateOur.Text.Length || j1 < 0) j1 = richTextBoxTranslateOur.Text.Length;
            if (j >= richTextBoxTranslateOur.Text.Length || j < 0) j = richTextBoxTranslateOur.Text.Length;
            j = Math.Min(j1, j);
            //if (article) j= richTextBoxWordTranslation.Text.IndexOf(' ', j + 1);
            richTextBoxTranslateOur.SelectionLength = j - lwst;
            richTextBoxTranslateOur.SelectionColor = Color.Blue;
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
                richTextBoxTranslate.Text = t3[0];
                richTextBoxTranslateOur.Text = t3[1];
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
                AllReadersSpeakAsynk();
                /*if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
                {
                    setStopPauseEnabled();

                    /* ReaderOriginal = new SpeechSynthesizer();
                     ReaderOriginal.SelectVoice("Microsoft Server Speech Text to Speech Voice (en-AU, Hayley)");

                     ReaderOriginal.SpeakAsync(richTextBoxOriginal.Text);
                     buttonPlay.Enabled = false;*/
                   /* AllReadersLoad();


                    //ReaderOriginal.SpeakCompleted += Reader_SpeakCompleted;                   
                }
                else
                {
                    MessageBox.Show("Type the text that needs to be told", Globals.INF, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
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
                if (ReaderOriginal.State == SynthesizerState.Speaking 
                    || ReaderTranslate.State == SynthesizerState.Speaking
                    || ReaderTranslateOur.State == SynthesizerState.Speaking)
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
            try
            {
                setStop();
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
            try
            {
                setStop();
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
           
            if (!string.IsNullOrEmpty(richTextBoxOriginal.Text)
                || !string.IsNullOrEmpty(richTextBoxTranslateOur.Text)
                || !string.IsNullOrEmpty(richTextBoxTranslate.Text))
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
                ReaderOriginal.SpeakCompleted -= Reader_SpeakCompleted;
                AllReadersDispose();
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
                AllReadersDispose();
                buttonPlay.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Readers
        /*На данном этапе процедура выбрасывает месенж об ошибке при любом збое и прекращает 
         * попытку извлечение настроек а все приводит к базовому
         * Потом нужно добавить продолжение извлечение и вывод об ошибке и месте извлечения 
         * */
        private void AllReadersLoad()
        {
            ReaderOriginal = new SpeechSynthesizer();
            ReaderTranslate = new SpeechSynthesizer();
            ReaderTranslateOur = new SpeechSynthesizer();
            _settingsequalizer = SettingsEqualizer.GetSettings();

            try
            {
                ReaderOriginal.SelectVoice(_settingsequalizer.VoiceNameLeft);
                ReaderTranslate.SelectVoice(_settingsequalizer.VoiceNameRight);
                ReaderTranslateOur.SelectVoice(_settingsequalizer.VoiceNameMid);
                
            }
            catch (Exception ex)
            {                
                ReaderOriginal.SelectVoice(Globals.SpeechSentizerVoice);
                ReaderTranslate.SelectVoice(Globals.SpeechSentizerVoice);
                ReaderTranslateOur.SelectVoice(Globals.SpeechSentizerVoice);
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllReadersDispose()
        {
            ReaderOriginal.Dispose();
            ReaderTranslateOur.Dispose();
            ReaderTranslate.Dispose();
        }

        private void AllReadersPause()
        {
            try
            {
                if (ReaderOriginal.State == SynthesizerState.Speaking)
                {
                    ReaderOriginal.Pause();
                }
                if (ReaderTranslateOur.State == SynthesizerState.Speaking)
                {
                    ReaderTranslateOur.Pause();
                }
                if (ReaderTranslate.State == SynthesizerState.Speaking)
                {
                    ReaderTranslate.Pause();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllReadersResume()
        {
            if (ReaderOriginal.State == SynthesizerState.Paused)
            {
                ReaderOriginal.Resume();
            }
            if (ReaderTranslateOur.State == SynthesizerState.Paused)
            {
                ReaderTranslateOur.Resume();
            }
            if (ReaderTranslate.State == SynthesizerState.Paused)
            {
                ReaderTranslate.Resume();
            }
        }

        private void AllReadersSpeakAsynk()
        {
            AllReadersLoad();
                setStopPauseEnabled();
            if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
            {  
                
                ReaderOriginal.SpeakAsync(richTextBoxOriginal.Text);
                ReaderOriginal.Pause();
            }

            if (!string.IsNullOrEmpty(richTextBoxTranslate.Text))
            {  
                
                ReaderTranslate.SpeakAsync(richTextBoxTranslate.Text);
                ReaderTranslate.Pause();
            }

            if (!string.IsNullOrEmpty(richTextBoxTranslateOur.Text))
            { 
                
                ReaderTranslateOur.SpeakAsync(richTextBoxTranslateOur.Text);
                ReaderTranslateOur.Pause();
            }
            AllReadersLoadSettings();
            AllReadersResume();
            buttonPlay.Enabled = false;
        }

        private void AllReadersLoadSettings()
        {
            AllReadersLoadVolume();
            AllReadersLoadRate();
        }

        private void AllReadersLoadVolume()
        {
            ReaderOriginal.Volume = _settingsequalizer.Volume;
            ReaderTranslate.Volume = _settingsequalizer.Volume;
            ReaderTranslateOur.Volume = _settingsequalizer.Volume;
        }

        private void AllReadersLoadRate()
        {
            ReaderOriginal.Rate = _settingsequalizer.Speed;
            ReaderTranslate.Rate = _settingsequalizer.Speed;
            ReaderTranslateOur.Rate = _settingsequalizer.Speed;
        }

        #endregion

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                AllReadersLoad();
            }                
        }
    }
}
