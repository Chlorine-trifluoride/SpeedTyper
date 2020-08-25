using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedTyper
{
    public enum CHAR_CORRECT_STATUS
    {
        UNKNOWN = 0,
        CORRECT = 1,
        INCORRECT = 2
    }

    struct TyperChar
    {
        public char Character { get; set; }
        public CHAR_CORRECT_STATUS CorrectStatus { get; set; }
    }
}
