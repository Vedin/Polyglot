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
        private int count = 0;
        //Параметры для выделения текста 

        //Индекси для выделений
        private int indexCurentWord = 0;
        private int lengthWordsBefore = 0;
        private int lengthSentencesBeforeInWords = 0;
        private int indexCurrentSentence = 0;
        private int lengthSentencesBeforeInSymbols = 0;

        //Масивы разделений
        private string[] Words = null;
        private string[] SentencesTranslate = null;

        private List<int> SentencesOriginalLengthInWords = new List<int>();

        private void SpeakProgresser(object sender, SpeakProgressEventArgs e)
        {
            count++;
            while ((Words.Length > indexCurentWord) && (Words[indexCurentWord].Length == 0))
            {
                lengthWordsBefore++;
                indexCurentWord++;
            }

            SelectTextOrifginal();
            SelectTextTranslate();
            CalculatedIndexersToSelentionText();
            

        }

        private void SelectTextTranslate()
        {
            richTextBoxTranslate.SelectAll();
            richTextBoxTranslate.SelectionColor = Color.Black;
            richTextBoxTranslate.SelectionBackColor = Color.White;

            richTextBoxLiteralTranslate.Text = Words.Length + "\n ------------\n" + count;
            richTextBoxTranslate.Select(lengthSentencesBeforeInSymbols, SentencesTranslate[indexCurrentSentence].Length);
            richTextBoxTranslate.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxTranslate.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
        }

        private void SelectTextOrifginal()
        {
            richTextBoxOriginal.SelectAll();
            richTextBoxOriginal.SelectionColor = Color.Black;
            richTextBoxOriginal.SelectionBackColor = Color.White;

            richTextBoxOriginal.Select(lengthWordsBefore, Words[indexCurentWord].Length);
            richTextBoxOriginal.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxOriginal.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
        }

        private void CalculatedIndexersToSelentionText()
        {
            AllReadersPause();
            if (indexCurentWord > lengthSentencesBeforeInWords + SentencesOriginalLengthInWords[indexCurrentSentence])
            {
                lengthSentencesBeforeInWords += SentencesOriginalLengthInWords[indexCurrentSentence];
                lengthSentencesBeforeInSymbols += SentencesTranslate[indexCurrentSentence].Length + 1;
                indexCurrentSentence++;
                Thread.Sleep(_settingsEqualizer.PauseSenteces);
            }

            if (Words[indexCurentWord].Length > 2) Thread.Sleep(_settingsEqualizer.PauseWords);

            AllReadersResume();

            lengthWordsBefore += Words[indexCurentWord].Length + 1;
            indexCurentWord++;
        }


        private void DefaultFieldsForSelectionText()
        {
            indexCurentWord = 0;
            lengthWordsBefore = 0;
            lengthSentencesBeforeInWords = 0;
            indexCurrentSentence = 0;
            lengthSentencesBeforeInSymbols = 0;
            count = 0;

            Words = null;
            SentencesTranslate = null;

            SentencesOriginalLengthInWords = new List<int>();
        }

        private void DividerSentecesOriginal()
        {
            foreach (string str in richTextBoxOriginal.Text.Split(sentenceSymbols))
            {
                SentencesOriginalLengthInWords.Add(str.Split(' ').Length - 1);
            }
        }

        public static double FlaschScore(int words, int sentences, int syllables)
        {
            return 206.835 - 1.015 * words / sentences - 84.6 * syllables / words;
        }
    }
}