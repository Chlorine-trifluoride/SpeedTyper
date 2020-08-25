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

                Render();
            }
        }

        public void Render(TyperChar[] chars)
        {
            typerChars = chars;

            Console.Clear();
            RenderTyperChars();
        }

        public void Render()
        {
            if (!(typerChars is null))
            {
                Console.Clear();
                RenderTyperChars();
            }
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

            Console.WriteLine(); // Empty line
        }

        private void SetRenderColor(ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
        }
    }
}
