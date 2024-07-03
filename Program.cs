using System;
using System.Threading;

namespace StudentsSelector
{
    public static class Program
    {
        private static string GetUserName()
        {
            Console.WriteLine("Para iniciar el programa debes ingresar tu nombre:");
            string? name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El usuario no ingresó ningún nombre. Por favor, ingrese su nombre:");
                Console.ResetColor();
                name = Console.ReadLine();
            }

            Console.WriteLine($"¡Hola, {name}! Ejecutando el programa...");
            Thread.Sleep(2000);
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
                            ProgramStudents.Init(); // Ejecutar la opción 1 (Init)
                            break;
                        case 2:
                            Console.Clear();
                            string[] students = ShowStudents.ShowStudentsF();

                            foreach (string student in students)
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case 3:
                            GetRidStudents.DeleteStudents();
                            break;
                        case 4:
                            // Implementar lógica para la opción 4
                            AddStudents.AddStudent();
                            break;
                        case 5:
                            
                            break;
                        case 6:
                            isProgramRunning = false; // Salir del programa
                            Environment.Exit(0);
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
