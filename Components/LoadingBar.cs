using System;
using System.Threading;
using System.Media;

namespace StudentsSelector
{
    public static class LoadingBar
    {
        public static void LoadingBarInit()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetWindowSize(150, 25);
            Console.Title = "Loading";

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            string text = "Teudy J. Encarnacion";
            int total = 50;

            int textX = (windowWidth - text.Length) / 2;
            int textY = windowHeight / 2 - 2;

            int barX = (windowWidth - total) / 2;
            int barY = windowHeight / 2;

            Console.SetCursorPosition(textX, textY);
            Console.Write(text);

            for (int i = 0; i <= total; i++)
            {
                Thread.Sleep(100);

                Console.SetCursorPosition(barX, barY);
                Console.Write("[");
                Console.Write(new string('#', i));
                Console.Write(new string(' ', total - i));
                Console.Write($"] {i * 2}%");

                Console.Out.Flush();
            }

            Console.SetCursorPosition((windowWidth - 17) / 2, barY + 2);
            Console.WriteLine("Loading complete!");

            Sounds.Intro();

            Thread.Sleep(12000);
        }
    }
}
