﻿using System;
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
    enum SettingsChanged
    {
        None,
        Text,
        Equlizer
    }

    
    partial class Form1 : Form
    {
        /*
         * Нужно будет удалить проверку на доступные голоса
         * Исправить ошибку что возоможно добавить только один голос (Microsoft Anna)
          
         * Добавить коментарии описывающие все 
         * 
         */

        public static AllTexts allTexts = AllTexts.GetAllTexts();
        #region Private members

        private SpeechSynthesizer ssO;
        private SpeechSynthesizer ss = new SpeechSynthesizer();
        int lwst = 0;

        //Ридеры для каждого бокса
        private SpeechSynthesizer ReaderOriginal = new SpeechSynthesizer();//Ридер оригинала
        private SpeechSynthesizer ReaderTranslate = new SpeechSynthesizer();
        private SpeechSynthesizer ReaderTranslateOur = new SpeechSynthesizer();


        //Параметры для выделения текста
        private int indexCurentWord = 0;
        private int lengthWordsBefore = 0;
        private int lengthSentencesBeforeInWords = 0;
        private int indexCurrentSentence = 0;
        private int lengthSentencesBeforeInSymbols = 0;

        private string[] Words = null;
        private string[] SentencesTranslate = null;

        private List<int> SentencesOriginalLengthInWords = new List<int>();


        private object _Lock = new object();

        //Для отслеживания изменения настроек
        /*
         * В дальнейшем можно передавать єтот параметр или дать возможность
         * его менять чтобы економить ресурсы и лишний раз не перезагружать настройки
         * 
         */ 
        private SettingsChanged settings = SettingsChanged.None;

        //Settings Members
        SettingsEqualizer _settingsEqualizer = null;

        SettingsText _settingsText = null;

        #endregion


        private char[] sentenceSymbols = { '.', '?', '!' };
        public string Massage(Exception ex)
        {
            return ex.Message + ex.Source;
        }

         

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

            /*foreach (var voice in Voices)
            {
                richTextBoxTranslate.Text += voice.Name + new string(' ', 1)/* + voice.InstalledVoice + new string('-',10) + '\n'*/;
            //}
            richTextBoxTranslate.Text = "Сторони цей Договір знову підтверджувати їх віра в цілі та принципи Хартія " +
                "Об’єднаний Нації та їх бажання жити у мир з усі народи та усі уряди." +
                "\nВони є визначений охороняти свободу, спільний спадщина та цивілізація їх народи," +
                " заснований на принципи демократія, індивідуальний свобода та правило закон.Вони прагнути " +
                "просувати стабільність та благополуччя в Північний Атлантичний район.";

            richTextBoxOriginal.Text = "The Parties to this Treaty reaffirm their faith in the purposes and principles " +
                "of the Charter of the United Nations and their desire to live in peace with all peoples and all governments." +
                "\nThey are determined to safeguard the freedom, common heritage and civilisation of their peoples, founded on" +
                " the principles of democracy, individual liberty and the rule of law. They seek to promote stability and well" +
                " - being in the North Atlantic area.";
        
            #endregion
        }

        #region Как я понял для рисовки( я єто даже не трогал)

        private void SelColor(int start_pos)
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
        private void SetColorO(int start_pos)
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
                richTextBoxOriginal.Text = t3[0];
                richTextBoxTranslateOur.Text = t3[1];
                richTextBoxTranslate.Text = t3[2];
            }
        }

        #endregion

        #region Buttons for Reader

        public void SpeakProgresser(object sender, SpeakProgressEventArgs e)
        {
            richTextBoxOriginal.SelectAll();
            richTextBoxOriginal.SelectionColor = Color.Black;
            richTextBoxOriginal.SelectionBackColor = Color.White;

            while ((Words.Length > indexCurentWord)&&(Words[indexCurentWord].Length == 0))
            {
                lengthWordsBefore++;
                indexCurentWord++;
            }
           
            richTextBoxOriginal.Select(lengthWordsBefore, Words[indexCurentWord].Length);
            richTextBoxOriginal.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxOriginal.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
            //----------------------------------------------------------------------------------

            richTextBoxTranslate.SelectAll();
            richTextBoxTranslate.SelectionColor = Color.Black;
            richTextBoxTranslate.SelectionBackColor = Color.White;


            richTextBoxTranslateOur.Text = "----------" + SentencesTranslate.Length + "--------" + SentencesTranslate[indexCurrentSentence];
            richTextBoxTranslate.Select(lengthSentencesBeforeInSymbols, SentencesTranslate[indexCurrentSentence].Length);
            richTextBoxTranslate.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxTranslate.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);


            if(indexCurentWord > lengthSentencesBeforeInWords + SentencesOriginalLengthInWords[indexCurrentSentence])
            {
                lengthSentencesBeforeInWords += SentencesOriginalLengthInWords[indexCurrentSentence];
                lengthSentencesBeforeInSymbols += SentencesTranslate[indexCurrentSentence].Length + 1;
                indexCurrentSentence++;
            }

            AllReadersPause();
            Thread.Sleep(100);
            AllReadersResume();

            lengthWordsBefore += Words[indexCurentWord].Length + 1;
            indexCurentWord++;       

        }
        void SpeakStarter(object sender, System.Speech.Synthesis.SpeakStartedEventArgs e)
        {
            
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
           
            try
            {             
                AllReadersSpeakAsynk();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.Source, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (ReaderOriginal.State == SynthesizerState.Paused
                    || ReaderTranslate.State == SynthesizerState.Paused
                    || ReaderTranslateOur.State == SynthesizerState.Paused)
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
                settings = SettingsChanged.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                || !string.IsNullOrEmpty(richTextBoxTranslateOur.Text)
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
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Readers
        /*На данном этапе процедура выбрасывает месенж об ошибке при любом збое и прекращает 
         * попытку извлечение настроек а все приводит к базовому
         * Потом нужно добавить продолжение извлечение и вывод об ошибке и месте извлечения 
         */
        private void AllReadersLoadVoice()
        {
            ReaderOriginal = new SpeechSynthesizer();
            ReaderTranslate = new SpeechSynthesizer();
            ReaderTranslateOur = new SpeechSynthesizer();
            _settingsEqualizer = SettingsEqualizer.GetSettings();

            try
            {
                ReaderOriginal.SelectVoice(_settingsEqualizer.VoiceNameLeft);
                ReaderTranslate.SelectVoice(_settingsEqualizer.VoiceNameRight);
                ReaderTranslateOur.SelectVoice(_settingsEqualizer.VoiceNameMid);
                
            }
            catch (Exception ex)
            {                
                ReaderOriginal.SelectVoice(Globals.SpeechSentizerVoice);
                ReaderTranslate.SelectVoice(Globals.SpeechSentizerVoice);
                ReaderTranslateOur.SelectVoice(Globals.SpeechSentizerVoice);
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllReadersDispose()
        {
            ReaderOriginal.Dispose();
            ReaderTranslateOur.Dispose();
            ReaderTranslate.Dispose();

            ReaderOriginal = new SpeechSynthesizer();
            ReaderTranslate = new SpeechSynthesizer();
            ReaderTranslateOur = new SpeechSynthesizer();
        }

        private void AllReadersPause()
        {
            try
            {
                if (ReaderOriginal.State == SynthesizerState.Speaking)
                {
                    ReaderOriginal.Pause();
                    
                }
               /* if (ReaderTranslateOur.State == SynthesizerState.Speaking)
                {
                    ReaderTranslateOur.Pause();
                    
                }
                if (ReaderTranslate.State == SynthesizerState.Speaking)
                {
                    ReaderTranslate.Pause();
                }*/                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.Source, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllReadersResume()
        {
            if (ReaderOriginal.State == SynthesizerState.Paused)
            {
                ReaderOriginal.Resume();
            }
            /*if (ReaderTranslateOur.State == SynthesizerState.Paused)
            {
                ReaderTranslateOur.Resume();
            }
            if (ReaderTranslate.State == SynthesizerState.Paused)
            {
                ReaderTranslate.Resume();
            }*/
        }

        private void AllReadersSpeakAsynk()
        {
            AllReadersLoadVoice();
            setStopPauseEnabled();
            /* if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
             {  

                 ReaderTranslate.SpeakAsync(richTextBoxOriginal.Text);
                 ReaderTranslate.Pause();
                 ReaderTranslate.SpeakCompleted += ReaderSpeakCompleted;
             }*/

            if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
            {

                ReaderOriginal.SpeakAsync(richTextBoxOriginal.Text);
                ReaderOriginal.Pause();
                ReaderOriginal.SpeakCompleted += ReaderSpeakCompleted;
                ReaderOriginal.SpeakStarted += SpeakStarter;
                ReaderOriginal.SpeakProgress += SpeakProgresser;

            }
            
           /* if (!string.IsNullOrEmpty(richTextBoxTranslateOur.Text))
            { 
                
                ReaderTranslateOur.SpeakAsync(richTextBoxTranslateOur.Text);
                ReaderTranslateOur.Pause();
                ReaderTranslateOur.SpeakCompleted += ReaderSpeakCompleted;
            }*/
            AllReadersLoadSettings();
            AllReadersResume();

            Words = richTextBoxOriginal.Text.Split(' ');

            SentencesTranslate = richTextBoxTranslate.Text.Split(sentenceSymbols);
            DividerSentecesOriginal();

            buttonPlay.Enabled = false;


        } 
        
        private void DividerSentecesOriginal()
        {
            foreach(string str in richTextBoxOriginal.Text.Split(sentenceSymbols))
            {
                SentencesOriginalLengthInWords.Add(str.Split(' ').Length - 1);
            }
        }

        private void AllReadersLoadSettings()
        {
            try
            {
                AllReadersLoadVolume();
                AllReadersLoadRate();
            }
            catch(Exception ex)
            {
                AllReadersLoadVolume(true);
                AllReadersLoadRate(true);
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                     
        }

        private void AllReadersLoadVolume(bool isDefault = false)
        {
            if(!isDefault)
            {
                ReaderOriginal.Volume = _settingsEqualizer.Volume;
                ReaderTranslate.Volume = _settingsEqualizer.Volume;
                ReaderTranslateOur.Volume = _settingsEqualizer.Volume;
            }
            else
            {
                ReaderOriginal.Volume = Globals.EqulizerVolumeDefault;
                ReaderTranslate.Volume = Globals.EqulizerVolumeDefault;
                ReaderTranslateOur.Volume = Globals.EqulizerVolumeDefault;
            }            
        }

        private void AllReadersLoadRate(bool isDefault = false)
        {
            if (!isDefault)
            {
                ReaderOriginal.Rate = _settingsEqualizer.Speed;
                ReaderTranslate.Rate = _settingsEqualizer.Speed;
                ReaderTranslateOur.Rate = _settingsEqualizer.Speed;
            }
            else
            {
                ReaderOriginal.Rate = Globals.EqulizerSpeedDefault;
                ReaderTranslate.Rate = Globals.EqulizerSpeedDefault;
                ReaderTranslateOur.Rate = Globals.EqulizerSpeedDefault;
            }
        }

        void ReaderSpeakCompleted(object sender, System.Speech.Synthesis.SpeakCompletedEventArgs e)
        {
            try
            {
                buttonPlay.Enabled = true;
                setStopPauseEnabled();
                /*ReaderOriginal.SpeakCompleted -= Reader_SpeakCompleted;
                AllReadersDispose();*/
                (sender as SpeechSynthesizer).SpeakCompleted -= ReaderSpeakCompleted;
                (sender as SpeechSynthesizer).Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
            //richTextBoxOriginal.Text = "Stop";
        }
        
        #endregion

        #region TextBoxes

        private void TextBoxLoadSettings(RichTextBox box ,bool isDefault = false)
        {
            if(isDefault)
            {
                box.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
                box.SelectionColor = Color.FromArgb(_settingsText.TextColor);
                box.Font = _settingsText.TextFont.GetFont();
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
                    richTextBoxTranslate.SelectAll();
                    //richTextBoxTranslate.SelectAll();
                    richTextBoxTranslateOur.SelectAll();

                    richTextBoxTranslate.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
                    richTextBoxTranslate.SelectionColor = Color.FromArgb(_settingsText.TextColor);
                    richTextBoxTranslate.Font = _settingsText.TextFont.GetFont();

                    richTextBoxOriginal.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
                    richTextBoxOriginal.SelectionColor = Color.FromArgb(_settingsText.TextColor);
                    richTextBoxOriginal.Font = _settingsText.TextFont.GetFont();

                    richTextBoxTranslateOur.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
                    richTextBoxTranslateOur.SelectionColor = Color.FromArgb(_settingsText.TextColor);
                    richTextBoxTranslateOur.Font = _settingsText.TextFont.GetFont();

                    richTextBoxTranslate.Select(0, 0);
                    richTextBoxOriginal.Select(0, 0);
                    richTextBoxTranslateOur.Select(0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {

            }                             
        }

        #endregion

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (settings==SettingsChanged.Equlizer)
            {
                AllReadersLoadVoice();
                AllReadersLoadSettings();
            }  
            if(settings==SettingsChanged.Text)
            {
                LoaderSettiingsForAllTextBox();
            }
            settings = SettingsChanged.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AllReadersLoadVoice();
                AllReadersLoadSettings();
                LoaderSettiingsForAllTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBoxTranslate_TextChanged(object sender, EventArgs e)
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

        public static double FlaschScore(int words, int sentences, int syllables)
        {
            return 206.835 - 1.015 * words / sentences - 84.6 * syllables / words;
        }


        private void додатиТекстДоБібліотекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddText formAddText = new FormAddText(this);          
            formAddText.Show();
            this.Hide();
            settings = SettingsChanged.None;

        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
          //  allTexts.Save();//Save all names and files of texts
        }
    }
}
