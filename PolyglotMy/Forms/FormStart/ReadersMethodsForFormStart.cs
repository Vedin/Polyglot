using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace PolyglotMy
{
    partial class Form1 : Form
    {
        private void AllReadersDispose()
        {
            ReaderOriginal.Dispose();
            ReaderOriginal = new SpeechSynthesizer();           
        }

        private void AllReadersPause()
        {
            try
            {
                if (ReaderOriginal.State == SynthesizerState.Speaking)
                {
                    ReaderOriginal.Pause();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Form1.Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllReadersResume()
        {
            if (ReaderOriginal.State == SynthesizerState.Paused)
            {
                ReaderOriginal.Resume();
            }
        }

        private void AllReadersSpeakAsynk()
        {
            AllReadersLoadVoice();
            setStopPauseEnabled();           

            if (!string.IsNullOrEmpty(richTextBoxOriginal.Text))
            {
                ReaderOriginal.SpeakAsync(richTextBoxOriginal.Text);
                ReaderOriginal.Pause();
                ReaderOriginal.SpeakCompleted += ReaderSpeakCompleted;
                ReaderOriginal.SpeakProgress += SpeakProgresser;
            }

            AllReadersLoadSettings();
            AllReadersResume();

            GetRealTextDivideTextByPhrase();
            DividerAllTexts();

            buttonPlay.Enabled = false;
        }

        void ReaderSpeakCompleted(object sender, System.Speech.Synthesis.SpeakCompletedEventArgs e)
        {
            try
            {
                buttonPlay.Enabled = true;
                setStopPauseEnabled();
                (sender as SpeechSynthesizer).SpeakCompleted -= ReaderSpeakCompleted;
                (sender as SpeechSynthesizer).Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}