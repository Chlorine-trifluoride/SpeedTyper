using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedTyper
{
    class Renderer
    {
        public TyperChar[] typerChars { get; set; }

        private int width, height;

        public Renderer()
        {
            this.width = Console.WindowWidth;
            this.height = Console.WindowHeight;
        }

        public void CheckIfSizeChangedAndReRender()
        {
            if (Console.WindowWidth != width || Console.WindowHeight != height)
            {
                this.width = Console.WindowWidth;
                this.height = Console.WindowHeight;

                Console.Clear();
                Render();
            }
        }

        public void Render(TyperChar[] chars)
        {
            typerChars = chars;

            RenderGame();
        }

        public void Render()
        {
            if (!(typerChars is null))
            {
                RenderGame();
            }
        }

        private void RenderGame()
        {
            RenderScore();
            Console.WriteLine(); // Empty Line

            RenderTyperChars();
            Console.WriteLine(); // Empty line
        }

        private void SetCursorPositionSafe(int x, int y)
        {
            if (x >= 0 && x < Console.WindowWidth &&
                y >= 0 && x < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
            }
        }

        private void RenderScore()
        {
            SetCursorPositionSafe(0, 0);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Score: {Score.UPoints} CPM");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void RenderTyperChars()
        {
            for (int i = 0; i < typerChars.Length; i++)
            {
                switch (typerChars[i].CorrectStatus)
                {
                    case CHAR_CORRECT_STATUS.UNKNOWN:
                        SetRenderColor(ConsoleColor.White);
                        break;

                    case CHAR_CORRECT_STATUS.CORRECT:
                        SetRenderColor(ConsoleColor.Green);
                        break;

                    case CHAR_CORRECT_STATUS.INCORRECT:
                        SetRenderColor(ConsoleColor.Red);
                        break;

                    default:
                        SetRenderColor(ConsoleColor.White);
                        break;
                }

                Console.Write(typerChars[i].Character);
            }
        }

        private void SetRenderColor(ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
        }
    }
}
