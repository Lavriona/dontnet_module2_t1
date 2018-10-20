using System;

namespace Training.Business.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Show Console Message with Color
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void ShowMessage(string message, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

