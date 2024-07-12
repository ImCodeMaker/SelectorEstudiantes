using System;
using System.Threading;
using System.Diagnostics;

namespace StudentsSelector
{
    public static class Program
    {
        private static string GetUserName()
        {
            LoadingBar.LoadingBarInit();
            Console.Clear();
            Thread.Sleep(5000);
            Console.ResetColor();
            Sounds.StartSound();
            Console.WriteLine("Para iniciar el programa debes ingresar tu nombre:");
            string? name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Sounds.Error();
                Console.WriteLine("El usuario no ingresó ningún nombre. Por favor, ingrese su nombre:");
                Console.ResetColor();
                name = Console.ReadLine();
            }
            Sounds.Acess();
            Console.WriteLine($"¡Hola, {name}! Ejecutando el programa...");
            Thread.Sleep(4000);
            return name;
        }

        public static void Main(string[] args)
        {
            bool isProgramRunning = true;
            string userName = GetUserName(); // Obtener el nombre de usuario una vez al inicio

            while (isProgramRunning)
            {
                Console.Clear();
                MainMenu.StartMenu(userName); // Mostrar menú principal

                string? userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int choice))
                {
                    HandleMenuChoice(choice, ref isProgramRunning);
                }
                else
                {
                    ShowInvalidOptionMessage();
                }
            }

            Environment.Exit(0);
        }

        private static void HandleMenuChoice(int choice, ref bool isProgramRunning)
        {
            switch (choice)
            {
                case 1:
                    ExecuteOption(ProgramStudents.Init);
                    break;
                case 2:
                    ExecuteOption(ShowStudentsF);
                    break;
                case 3:
                    ExecuteOption(GetRidStudents.DeleteStudents);
                    break;
                case 4:
                    ExecuteOption(AddStudents.AddStudent);
                    break;
                case 5:
                    ExecuteOption(MyClass.Clear);
                    break;
                case 6:
                    isProgramRunning = false;
                    Console.Clear();
                    break;
                case 7:
                    OpenYouTubeVideo("https://www.youtube.com/watch?v=xvFZjo5PgG0");
                    break;
                default:
                    ShowInvalidOptionMessage();
                    break;
            }
        }

        private static void ExecuteOption(Action action)
        {
            Console.Clear();
            action();
            Console.ResetColor();
            Console.Clear();
        }

        private static void ShowStudentsF()
        {
            ShowStudents.ShowStudentsF();
            Console.WriteLine("\nPresiona cualquier tecla para regresar al menú principal...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void OpenYouTubeVideo(string url)
        {
            Console.WriteLine("Opening the YouTube video...");
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private static void ShowInvalidOptionMessage()
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
            Thread.Sleep(2000);
        }
    }
}
