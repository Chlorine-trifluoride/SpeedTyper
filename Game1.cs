using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedTyper
{
    class Game1
    {
        private TextLoader textLoader;

        private string text;
        private string[] words;

        private TyperChar[] typerChars;

        private uint numCorrect = 0;
        private uint numIncorrect = 0;

        public Game1()
        {
            textLoader = new TextLoader();
            LoadText();
        }

        private void LoadText()
        {
            text = textLoader.GetRandomText();
            words = text.Split(' ');

            typerChars = new TyperChar[text.Length];

            for (int i = 0; i < typerChars.Length; i++)
            {
                typerChars[i].Character = text[i];
            }
        }

        public void Run()
        {
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

        private bool ValidateInput(string word, string input)
        {
            if (word == input)
                return true;

            return false;
        }
    }
}
