using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpeedTyper
{
    class TextLoader
    {
        private const string textPath = @"Media/test_short.txt";

        public string GetRandomText()
        {
            string result = "lorem ipsum";

            using (StreamReader reader = new StreamReader(textPath))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
