using System;

namespace StudentsSelector
{
    public static class ShowStudents
    {
        public static void ShowStudentsF()
        {
            Console.Clear();

            string[] asciiArt = {
                @"███████╗░██████╗████████╗██╗░░░██╗██████╗░██╗░█████╗░███╗░░██╗████████╗███████╗░██████╗",
                @"██╔════╝██╔════╝╚══██╔══╝██║░░░██║██╔══██╗██║██╔══██╗████╗░██║╚══██╔══╝██╔════╝██╔════╝",
                @"█████╗░░╚█████╗░░░░██║░░░██║░░░██║██║░░██║██║███████║██╔██╗██║░░░██║░░░█████╗░░╚█████╗░",
                @"██╔══╝░░░╚═══██╗░░░██║░░░██║░░░██║██║░░██║██║██╔══██║██║╚████║░░░██║░░░██╔══╝░░░╚═══██╗",
                @"███████╗██████╔╝░░░██║░░░╚██████╔╝██████╔╝██║██║░░██║██║░╚███║░░░██║░░░███████╗██████╔╝"
            };

            // Print ASCII art in the center of the screen
            CenterText(asciiArt);

            string[] validStudents = GetValidStudents();

            // Display students in a centered box below the ASCII art
            DisplayInCenteredBox(validStudents, asciiArt.Length);

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CenterText(string[] textLines)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Calculate top position for centering vertically
            int top = (consoleHeight - textLines.Length) / 2;

            // Ensure position is within valid range
            if (top < 0) top = 0;

            // Display each line of text centered horizontally
            foreach (string line in textLines)
            {
                int left = (consoleWidth - line.Length) / 2;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(line);
            }
        }

        private static string[] GetValidStudents()
        {
            int validCount = 0;

            // Count non-empty student names
            for (int i = 0; i < StudentsList.AllStudents.Length; i++)
            {
                if (!string.IsNullOrEmpty(StudentsList.AllStudents[i]))
                {
                    validCount++;
                }
            }

            // Create array for valid student names
            string[] validStudents = new string[validCount];
            int index = 0;

            // Populate valid student names
            for (int i = 0; i < StudentsList.AllStudents.Length; i++)
            {
                if (!string.IsNullOrEmpty(StudentsList.AllStudents[i]))
                {
                    validStudents[index] = StudentsList.AllStudents[i];
                    index++;
                }
            }

            return validStudents;
        }

        private static void DisplayInCenteredBox(string[] items, int asciiArtHeight)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Determine box dimensions
            int longestLineLength = 0;
            foreach (string item in items)
            {
                if (item.Length > longestLineLength)
                {
                    longestLineLength = item.Length;
                }
            }

            int boxWidth = longestLineLength + 4;
            int boxHeight = items.Length + 2; 

            // Calculate top position for the box (below the ASCII art)
            int top = (consoleHeight + asciiArtHeight) / 2 + 1; // Adding 1 for padding
            int left = (consoleWidth - boxWidth) / 2;

            // Ensure positions are within valid range
            if (top < 0) top = 0;
            if (left < 0) left = 0;

            // Display box
            Console.SetCursorPosition(left, top);
            Console.WriteLine("╔" + new string('═', boxWidth - 2) + "╗");

            for (int i = 0; i < items.Length; i++)
            {
                Console.SetCursorPosition(left, Console.CursorTop);
                Console.WriteLine("║ " + items[i].PadRight(longestLineLength) + " ║");
            }

            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine("╚" + new string('═', boxWidth - 2) + "╝");
        }
    }
}
