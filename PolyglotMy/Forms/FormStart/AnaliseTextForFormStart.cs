using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.Text.RegularExpressions;

namespace PolyglotMy
{
    partial class Form1 : Form
    {

        //Символи для анализа и деления текста 
        public static readonly char[] splitSentenceSymbols = { '.', '?', '!' };
        public static readonly char[] splitWordsSymbols = { ' ', '\n' ,'\t'};
        public static readonly string[] splitPrases = new string[] { "###|###" };
        private Regex regexReadWord = new Regex(@"[0-9A-Za-z]");

        //Индекси для выделений 
        //Общие
        private int indexCurrentSentence = 0;
        private int indexCurrentPrase = 0;
        //Оригинал
        private int indexOriginalCurentWord = 0;
        private int lengthSentenceOriginalWordsBefore = 0;
        private int lengthSentenceOriginalBeforeInWords = 0;
        private int lengthOriginalPhrasesBeforeInWords = 0;
        private int lengthOriginalPrasesBefore = 0;

        //Перевод
        private int lengthTranslateSentencesBeforeInSymbols = 0;
        //Дословный перевод        
        private int lengthLiteralTranslatePrasesBefore = 0;

        //Масивы разделений текста после обработки на слова фразы и предложения
        private string[] wordsOriginal = null;
        private string[] praseOriginal = null;

        private string[] praseLiteralTranslate = null;

        private string[] sentencesTranslate = null;

        private List<int> sentencesOriginalLengthInWords = new List<int>();
        private List<int> prasesOriginalLengthInWords = new List<int>();

        private void SpeakProgresser(object sender, SpeakProgressEventArgs e)
        {
            //для пропуска слов что не читаються к примеру просто различних знаков припинания
            while(!regexReadWord.IsMatch(wordsOriginal[indexOriginalCurentWord]))
            {
                CalculatedIndexersToSelentionText();
            }

            SelectTextOrifginal();
            SelectTextTranslate();
            SelectTextLiteralTranslate();
           
            AllReadersPause();
            CalculatedIndexersToSelentionText();
            AllReadersResume();
            
        }

        private void SelectTextTranslate()
        {
            richTextBoxTranslate.SelectAll();
            richTextBoxTranslate.SelectionColor = Color.Black;
            richTextBoxTranslate.SelectionBackColor = Color.White;

            richTextBoxTranslate.Select(lengthTranslateSentencesBeforeInSymbols, sentencesTranslate[indexCurrentSentence].Length);
            richTextBoxTranslate.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxTranslate.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
        }

        private void SelectTextOrifginal()
        {
            richTextBoxOriginal.SelectAll();
            richTextBoxOriginal.SelectionColor = Color.Black;
            richTextBoxOriginal.SelectionBackColor = Color.White;

            richTextBoxOriginal.Select(lengthSentenceOriginalWordsBefore, wordsOriginal[indexOriginalCurentWord].Length);
            richTextBoxOriginal.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxOriginal.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
        }

        private void SelectTextLiteralTranslate()
        {
            richTextBoxLiteralTranslate.SelectAll();
            richTextBoxLiteralTranslate.SelectionColor = Color.Black;
            richTextBoxLiteralTranslate.SelectionBackColor = Color.White;

            richTextBoxLiteralTranslate.Select(lengthLiteralTranslatePrasesBefore, praseLiteralTranslate[indexCurrentPrase].Length);
            richTextBoxLiteralTranslate.SelectionColor = Color.FromArgb(_settingsText.TextColor);
            richTextBoxLiteralTranslate.SelectionBackColor = Color.FromArgb(_settingsText.BackColor);
        }
        private void CalculatedIndexersToSelentionText(bool Pause = true)
        {          
            if (indexOriginalCurentWord > lengthSentenceOriginalBeforeInWords + sentencesOriginalLengthInWords[indexCurrentSentence])
            {
                lengthSentenceOriginalBeforeInWords += sentencesOriginalLengthInWords[indexCurrentSentence];
                lengthTranslateSentencesBeforeInSymbols += sentencesTranslate[indexCurrentSentence].Length + 1;
                indexCurrentSentence++;
                if(Pause) Thread.Sleep(_settingsEqualizer.PauseSenteces);
            }

            if (indexOriginalCurentWord >= lengthOriginalPhrasesBeforeInWords + prasesOriginalLengthInWords[indexCurrentPrase])
            {               
                lengthOriginalPhrasesBeforeInWords += prasesOriginalLengthInWords[indexCurrentPrase];
                lengthOriginalPrasesBefore += praseOriginal[indexCurrentPrase].Length;
                lengthLiteralTranslatePrasesBefore += praseLiteralTranslate[indexCurrentPrase].Length;

                indexCurrentPrase++;
            }


            if (Pause) if (wordsOriginal[indexOriginalCurentWord].Length > 2) Thread.Sleep(_settingsEqualizer.PauseWords);

            lengthSentenceOriginalWordsBefore += wordsOriginal[indexOriginalCurentWord].Length + 1;
            indexOriginalCurentWord++;

        }           


        private void DefaultFieldsForSelectionText()
        {
            //анулирование параметров для выделения слов в Оригинал(Original)
            indexOriginalCurentWord = 0;
            lengthSentenceOriginalWordsBefore = 0;
            lengthSentenceOriginalBeforeInWords = 0;
            lengthOriginalPrasesBefore = 0;
            lengthOriginalPhrasesBeforeInWords = 0;

            //анулирование параметров для вделения предложений в Переводе(Traslate)
            indexCurrentSentence = 0;
            lengthTranslateSentencesBeforeInSymbols = 0;

            //анулирование для дословного перевода(Literal Translate)
            indexCurrentPrase = 0;

            lengthLiteralTranslatePrasesBefore = 0;
            
            wordsOriginal = null;
            praseLiteralTranslate = null;
            praseOriginal = null;
            sentencesTranslate = null;

            sentencesOriginalLengthInWords = new List<int>();
        }

        private void DividerSentecesOriginal()
        {
            foreach (string str in richTextBoxOriginal.Text.Split(splitSentenceSymbols))
            {
                sentencesOriginalLengthInWords.Add(str.Split(splitWordsSymbols).Length - 1);
            }
        }
        private void DividerPrasesOriginal()
        {
            foreach (string str in praseOriginal)
            {
                prasesOriginalLengthInWords.Add(str.Split(splitWordsSymbols).Length - 1);
            }
        }

        public static double FlaschScore(int words, int sentences, int syllables)
        {
            return 206.835 - 1.015 * words / sentences - 84.6 * syllables / words;
        }

        private void GetRealTextDivideTextByPhrase()
        {
            string[] prases = null;
            for (int i = 0; i < text.Length; i++)
            {                
                prases = text[i].Split(splitPrases, StringSplitOptions.RemoveEmptyEntries);
                textForBoxes[i] = "";
                foreach(string str in prases)
                {
                    textForBoxes[i] += str;
                }
                switch (i)
                {
                    case 0: praseOriginal = prases;
                        break;
                    case 1: praseLiteralTranslate = prases;
                        break;
                }
            }
            //MessageBox.Show("praseLiteralTranslate" + praseLiteralTranslate.Length +"   "+ praseOriginal.Length, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DividerAllTexts()
        {
            wordsOriginal = richTextBoxOriginal.Text.Split(splitWordsSymbols);

            sentencesTranslate = richTextBoxTranslate.Text.Split(splitSentenceSymbols);
            DividerSentecesOriginal();
            DividerPrasesOriginal();
        }
    }
}