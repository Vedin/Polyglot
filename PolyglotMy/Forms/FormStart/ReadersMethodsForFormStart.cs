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
                //ReaderOriginal.SpeakStarted += SpeakStarter;
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
    }
}