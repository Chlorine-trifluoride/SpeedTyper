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
                    typerChars[index].CorrectStatus = CHAR_CORRECT_STATUS.CORRECT;
                else
                    typerChars[index].CorrectStatus = CHAR_CORRECT_STATUS.INCORRECT;

                // Render all the text again
                render.Render(typerChars);
            }

            //for (int index = 0; index < words.Length; index++)
            //{
            //    string word = words[index];
            //    Console.WriteLine(word);

            //    string input = Console.ReadLine();

            //    if (ValidateInput(word, input))
            //        Console.WriteLine("Correct");
            //    else
            //        Console.WriteLine("Incorrect");

            //    // do points
            //    index++;
            //}
        }

        private bool ValidateInput(string word, string input)
        {
            if (word == input)
                return true;

            return false;
        }
    }
}
