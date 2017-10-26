using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Speech.Synthesis;
using System.Speech.Synthesis;
using System.IO;
using System.Text.RegularExpressions;

namespace PolyglotMy
{
    public partial class Form1 : Form
    {
        private SpeechSynthesizer ss,ssO;
        int lwst = 0;
        public Form1()
        {
            
            InitializeComponent();
            ssO = new SpeechSynthesizer();
            ssO.Volume = 0;
            ssO.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgressO);
            //ssO.Rate = 2;
            ss = new SpeechSynthesizer();
            ss.SelectVoice("Microsoft Zira Desktop");
            //-ss.Volume = 100;// от 0 до 100
            ss.Rate = trackBarSpeed.Value;//от -10 до 10
            ss.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);
        }
        private void SelColor(int start_pos)
        {
            int j = 0;
            richTextBox1.SelectionColor=Color.Black;
            richTextBox1.SelectionStart = start_pos;
            j = richTextBox1.Text.IndexOf(' ', start_pos);
            int j1= richTextBox1.Text.IndexOf('\n', start_pos);
            if (j1 >= richTextBox1.Text.Length || j1 < 0) j1 = richTextBox1.Text.Length;
            if (j >= richTextBox1.Text.Length || j<0) j = richTextBox1.Text.Length;
            j = Math.Min(j1, j);
            richTextBox1.SelectionLength = j-start_pos;
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
            if (!article) lwst = j+1;
        }
        private void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            if (e.Text == "The" || e.Text == "the" || e.Text == "A" || e.Text == "a" || e.Text=="to" || e.Text=="of") return;
            else SetColorWT(false);
            SelColor(e.CharacterPosition);
            //Console.WriteLine("Current word being spoken: " + e.Text);
        }
        private void synth_SpeakProgressO(object sender, SpeakProgressEventArgs e)
        {
            SetColorO(e.CharacterPosition);
            //Console.WriteLine("Current word being spoken: " + e.Text);
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            ss.SpeakAsyncCancelAll();
            ssO.SpeakAsyncCancelAll();
            lwst =0;
            richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionStart = 0;
                richTextBox1.SelectionLength = 0;
                buttonPlay.Enabled = false;
            ss.Volume = trackBarVolume.Value;
            ss.Rate = trackBarSpeed.Value;
            ssO.Rate = Math.Min(trackBarSpeed.Value + 2,10);
                ssO.SpeakAsync(richTextBoxOriginal.Text);
                ss.SpeakAsync(richTextBox1.Text);
                buttonPlay.Enabled = true;
            
        }

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
                    textAll=sw.ReadToEnd();
                string[] t3 = Regex.Split(textAll, @"###");
                richTextBox1.Text = t3[0];
                richTextBoxWordTranslation.Text = t3[1];
                richTextBoxOriginal.Text = t3[2];
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (ss.State.ToString() == "Paused")
            {
                ss.Resume();
                ssO.Resume();
            }
            else
            {
                ss.Pause();
                ssO.Pause();
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings Fset = new FormSettings(this);
            Fset.Show();
            Hide();
        }
    }
}
