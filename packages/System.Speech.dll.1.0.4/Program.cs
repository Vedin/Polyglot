using System;
using System.Speech.Recognition;
using MailKit;
//using System.Speech.Synthesis;

namespace Voice_Recognation
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
            recEngine.SetInputToDefaultAudioDevice();  

            Choices commands = new Choices();
            commands.Add(new string[] { "say Hi", "say Hello"});
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);
            Grammar g = new Grammar(gb);

            recEngine.LoadGrammarAsync(g);
            recEngine.RecognizeAsync(RecognizeMode.Multiple);

            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            
        }

                // Create a simple handler for the SpeechRecognized event
        static void recEngine_SpeechRecognized (object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized: {0}", e.Result.Text);
            switch(e.Result.Text){
                case "Red":
                    Console.WriteLine("you said hi"); 
                break;
              //  default:
              //  break;
            }
        }

    }
}
