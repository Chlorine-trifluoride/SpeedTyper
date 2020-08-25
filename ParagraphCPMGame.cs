using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpeedTyper
{
    [Description("Choose a text to write. You get points for every correct character divided by time.")]
    class ParagraphCPMGame : IGameMode
    {
        private TextLoader textLoader;

        private string text;
        private string[] words;

        private TyperChar[] typerChars;

        private uint numCorrect = 0;
        private uint numIncorrect = 0;

        public ParagraphCPMGame()
        {
            textLoader = new TextLoader();
        }

        private string GetFileNameFromMenu()
        {
            string[] fileNames = textLoader.GetFileNames();

            Console.Clear();
            Console.WriteLine("Select Text File:");
            Console.WriteLine("------------------");

            for (int i = 0; i < fileNames.Length; i++)
            {
                Console.WriteLine($"{i}) {fileNames[i]}");
            }

            for (; ; )
            {
                // use the array indexes for input selection, saves us a switch
                char key = Console.ReadKey().KeyChar;
                if (int.TryParse(key.ToString(), out int selection))
                {
                    if (selection < fileNames.Length)
                        return fileNames[selection];
                }
            }
        }

        private void LoadText(string fileName)
        {
            text = textLoader.GetTextFromFile(fileName);
            words = text.Split(' ');

            typerChars = new TyperChar[text.Length];

            for (int i = 0; i < typerChars.Length; i++)
            {
                typerChars[i].Character = text[i];
            }
        }

        public void Run()
        {
            string fileName = GetFileNameFromMenu();
            LoadText(fileName);

            // Clear console of menus
            Console.Clear();

            // Render all the text again
            Renderer render = new Renderer();
            render.Render(typerChars);

            // Start the score time
            Score.StartTimer();

            for (int index = 0; index < typerChars.Length; index++)
            {
                while (!Console.KeyAvailable)
                {
                    System.Threading.Thread.Sleep(1);
                    render.CheckIfSizeChangedAndReRender();
                }

                // Console key is now available
                char inputChar = Console.ReadKey(true).KeyChar;
                if (inputChar == typerChars[index].Character)
                {
                    typerChars[index].CorrectStatus = CHAR_CORRECT_STATUS.CORRECT;
                    numCorrect++;
                }

                else
                {
                    typerChars[index].CorrectStatus = CHAR_CORRECT_STATUS.INCORRECT;
                    numIncorrect++;
                }

                // Calculate the score
                Score.CalculatePoints(numCorrect);

                // Render all the text again
                render.Render(typerChars);
            }
        }
    }
}
