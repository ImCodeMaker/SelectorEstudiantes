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
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.ResetColor();
                            Console.Clear();
                            ProgramStudents.Init(); // Ejecutar la opción 1 (Init)
                            break;
                        case 2:
                            Console.Clear();
                            Console.ResetColor();
                            ShowStudents.ShowStudentsF();
                            Console.WriteLine("\nPresiona cualquier tecla para regresar al menú principal...");
                            Console.ReadKey(true); 
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        case 3:
                            Console.ResetColor();
                            GetRidStudents.DeleteStudents();
                            break;
                        case 4:

                            AddStudents.AddStudent();
                            break;
                        case 5:
                            Console.Clear();
                            isProgramRunning = false;
                            Console.ResetColor();
                            Console.Clear();
                            
                            Environment.Exit(0);
                            break;
                        case 6:
                            string url = "https://www.youtube.com/watch?v=xvFZjo5PgG0";

                            Console.WriteLine("Opening the YouTube video...");
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true
                            });
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    Thread.Sleep(2000);
                }
            }

            Environment.Exit(0);
        }
    }
}