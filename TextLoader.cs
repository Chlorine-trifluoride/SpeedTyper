using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpeedTyper
{
    class TextLoader
    {
        private const string textPath = @"Media/";

        public string GetTextFromFile(string fileName)
        {
            string result = "lorem ipsum";

            using (StreamReader reader = new StreamReader($"{fileName}"))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public string[] GetFileNames()
        {
            string[] files = Directory.GetFiles(textPath, "*.txt");
            return files;
        }
    }
}
