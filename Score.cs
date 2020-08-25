using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedTyper
{
    static class Score
    {
        public static float Points { get; set; } = 0;
        public static uint UPoints => (uint)Points;

        private static DateTime startTime;
        private static uint elapsedSeconds => (uint)(DateTime.Now - startTime).TotalSeconds;

        public static void StartTimer()
        {
            startTime = DateTime.Now;
        }

        public static void CalculatePoints(uint numCorrectLetters)
        {
            if (elapsedSeconds != 0) // avoid division by 0
                 Points = (float)numCorrectLetters / elapsedSeconds * 60.0f; // Get letters per minute
        }
    }
}
