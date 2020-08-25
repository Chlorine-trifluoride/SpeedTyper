using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpeedTyper
{
    class MainMenu
    {
        public void Run()
        {
            var type = typeof(IGameMode);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            PrintLoadedMainMenu(types);
        }

        private void PrintLoadedMainMenu(IEnumerable<Type> gameModes)
        {
            Console.Clear();
            Console.WriteLine("Select Game Mode:");
            Console.WriteLine("------------------");

            Type[] gameModeArray = gameModes.ToArray();

            for (int i = 0; i < gameModeArray.Length; i++)
            {
                Type t = gameModeArray[i];
                Console.WriteLine($"{i}) {t.Name} - {GetDescriptionAttributeText(t)}");
            }

            // use the array indexes for input selection, saves us a switch
            char key = Console.ReadKey().KeyChar;
            if (int.TryParse(key.ToString(), out int selection))
            {
                if (selection >= gameModeArray.Length)
                    return;

                // Clear console when game mode is selected
                Console.Clear();

                // Create instance of the game mode and run it
                IGameMode gameMode = Activator.CreateInstance(gameModeArray[selection]) as IGameMode;
                gameMode.Run();

                Console.ReadKey();
            }
        }

        private string GetDescriptionAttributeText(Type t)
        {
            string result = "";
            DescriptionAttribute description = (DescriptionAttribute)t.GetCustomAttribute(typeof(DescriptionAttribute));
            result = description?.Description;

            return result;
        }
    }
}
