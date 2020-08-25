using System;

namespace SpeedTyper
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Run();

            // Reset console colors
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
