using System;

namespace StudentsSelector
{
    public static class MainMenu
    {
        public static void StartMenu(string userName)
        {
            Console.Clear();
            Console.Clear(); // En caso de que el otro no funcione XD
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            CenterText(@"
                                                        ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
                                                        ████╗░████║██╔════╝████╗░██║██║░░░██║
                                                        ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
                                                        ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
                                                        ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
                                                    ");

            string[] menuOptions = {
                "1. Iniciar el juego",
                "2. Ver la lista de Estudiantes",
                "3. Eliminar un Estudiante",
                "4. Agregar un Estudiante",
                "5. Salir",
                "6. Opcion Secreta"
            };

            foreach (var option in menuOptions)
            {
                DrawBoxAroundText(option);
            }

            Console.Write("Seleccione una opción: ");
        }

        private static void CenterText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textWidth = text.Length;
            int padding = (windowWidth - textWidth) / 2;
            Console.WriteLine(text.PadLeft(padding + textWidth));
        }

        private static void DrawBoxAroundText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textWidth = text.Length + 4; // Adding padding for the box
            int padding = (windowWidth - textWidth) / 2;

            string topBottomBorder = new string('═', textWidth);
            string paddedText = "║ " + text + " ║";

            Console.WriteLine(new string(' ', padding) + "╔" + topBottomBorder + "╗");
            Console.WriteLine(new string(' ', padding) + paddedText);
            Console.WriteLine(new string(' ', padding) + "╚" + topBottomBorder + "╝");
        }
    }
}

