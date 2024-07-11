using System;
using System.Threading;

namespace StudentsSelector
{
    public static class ProgramStudents
    {
        private static string? Role;
        
        public const string NameFile = "StudentResult.xlsx";
        private static string? Role2;
        private static bool UserAssignedRoles = false;
        private static Random random = new Random(); // Generador aleatorio único

        public static void Init()
        {
            Console.ResetColor();
            Console.Clear();
            Console.Clear();
            bool programRunning = true;

            while (programRunning)
            {
                Console.ResetColor();
                Console.Clear();
                Console.Clear();
                Console.WriteLine("Bienvenido al Selector de Usuarios");
                Console.WriteLine("¿Desea continuar o salir?");
                Console.WriteLine("Ingrese 'Si' para continuar, 'Volver' para volver al menú principal, o 'Salir' para finalizar.");

                string? userAnswer = Console.ReadLine()?.ToLower();

                switch (userAnswer)
                {
                    case "si":
                        Console.Clear();
                        try
                        {
                            if (!UserAssignedRoles)
                            {
                                Console.WriteLine($"Antes de continuar, ¿deseas modificar los roles? Escribe 'Si' para continuar, 'No' para seguir con la ejecución.");
                                string? UserResponse = Console.ReadLine()?.ToLower();

                                if (UserResponse == "si")
                                {
                                    Console.WriteLine($"Ingrese el nuevo rol:");
                                    Role = Console.ReadLine();

                                    Console.WriteLine($"¿Quieres modificar el segundo rol?");
                                    string? UserResponse2 = Console.ReadLine()?.ToLower();

                                    if (UserResponse2 == "si")
                                    {
                                        Console.WriteLine($"Ingrese el nuevo segundo rol:");
                                        Role2 = Console.ReadLine();
                                    }

                                    UserAssignedRoles = true;
                                }
                                else if (UserResponse == "no")
                                {
                                    Console.WriteLine("Continuando con la ejecución sin modificar roles.");
                                    UserAssignedRoles = true;
                                }
                            }

                            Console.ResetColor();
                            Console.Clear();

                            MostrarTexto();

                            for (int i = 0; i < 10; i++)
                            {
                                Console.Write(".");
                                Thread.Sleep(500); // Adjust the sleep time to change animation speed
                            }

                            Console.WriteLine();
                            Console.WriteLine("Loading Complete!");
                            Thread.Sleep(5000);

                            string developer = SelectStudent(Role ?? "Desarrollador en Vivo:");
                            string facilitator = SelectStudent(Role2 ?? "Facilitador:");

                            if (developer == "NO_STUDENTS_AVAILABLE" || facilitator == "NO_STUDENTS_AVAILABLE")
                            {
                                Console.WriteLine("No hay suficientes estudiantes disponibles.");
                                ProgramExecution();
                                programRunning = false;
                            }
                            else
                            {
                                MostrarTexto();
                                Console.WriteLine($"{Role} seleccionado: {developer}");
                                Console.WriteLine($"{Role2} seleccionado: {facilitator}");
                                DateTime now = DateTime.Now;
                                string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss");
                                Sounds.Final();
                                Excel.AddToExcelFile(NameFile,developer,facilitator,formattedDate);
                                Thread.Sleep(10000);
                                if (developer == "LAST_STUDENT_SELECTED")
                                {
                                    Console.WriteLine("¡Todos los estudiantes han sido asignados roles!");
                                    ProgramExecution();
                                    programRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                                    Console.ReadKey();
                                }
                            }
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.WriteLine("Se ha producido un error. Reiniciando el programa...");
                            Thread.Sleep(2000);
                            Console.Clear();
                            ProgramExecution();
                            programRunning = false;
                        }
                        break;
                    case "volver":
                        programRunning = false;
                        break;
                    case "salir":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }

        public static void MostrarTexto()
        {
            Console.WriteLine(@"
                            
                            
                            
                                                                            
                                                ░██████╗████████╗██╗░░░██╗██████╗░███████╗███╗░░██╗████████╗
                                                ██╔════╝╚══██╔══╝██║░░░██║██╔══██╗██╔════╝████╗░██║╚══██╔══╝
                                                ╚█████╗░░░░██║░░░██║░░░██║██║░░██║█████╗░░██╔██╗██║░░░██║░░░
                                                ░╚═══██╗░░░██║░░░██║░░░██║██║░░██║██╔══╝░░██║╚████║░░░██║░░░
                                                ██████╔╝░░░██║░░░╚██████╔╝██████╔╝███████╗██║░╚███║░░░██║░░░
                                                ╚═════╝░░░░╚═╝░░░░╚═════╝░╚═════╝░╚══════╝╚═╝░░╚══╝░░░╚═╝░░░

                                                ░██████╗███████╗██╗░░░░░███████╗░█████╗░████████╗██╗░█████╗░███╗░░██╗
                                                ██╔════╝██╔════╝██║░░░░░██╔════╝██╔══██╗╚══██╔══╝██║██╔══██╗████╗░██║
                                                ╚█████╗░█████╗░░██║░░░░░█████╗░░██║░░╚═╝░░░██║░░░██║██║░░██║██╔██╗██║
                                                ░╚═══██╗██╔══╝░░██║░░░░░██╔══╝░░██║░░██╗░░░██║░░░██║██║░░██║██║╚████║
                                                ██████╔╝███████╗███████╗███████╗╚█████╔╝░░░██║░░░██║╚█████╔╝██║░╚███║
                                                ╚═════╝░╚══════╝╚══════╝╚══════╝░╚════╝░░░░╚═╝░░░╚═╝░╚════╝░╚═╝░░╚══╝
                            

                            ");
        }

        public static string SelectStudent(string role)
        {
            Role ??= "Desarrollador en vivo";
            Role2 ??= "Facilitador";

            int studentCount = StudentsList.GetStudentCount();
            if (studentCount == 0)
            {
                return "NO_STUDENTS_AVAILABLE";
            }

            bool isOdd = studentCount % 2 != 0;
            int randomIndex = random.Next(studentCount);

            if (isOdd && studentCount == 1)
            {
                string selectedStudent = StudentsList.AllStudents[0];
                StudentsList.AssignedRoles[selectedStudent] = role;
                StudentsList.RemoveStudentAt(0);

                // Display selection
                Console.Clear();
                Console.WriteLine("════════════════════════════════════════");
                Console.WriteLine("          ¡Seleccionado!                  ");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"¡Hola {selectedStudent}!");
                Console.WriteLine($"Eres seleccionado como {role}.");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();



                return "LAST_STUDENT_SELECTED";
            }

            int attempts = 0;
            while (attempts < studentCount * 2)
            {
                int index = randomIndex % studentCount;
                string selectedStudent = StudentsList.AllStudents[index];

                if (!string.IsNullOrEmpty(selectedStudent) &&
                    (!StudentsList.AssignedRoles.ContainsKey(selectedStudent) || StudentsList.AssignedRoles[selectedStudent] != role))
                {
                    StudentsList.AssignedRoles[selectedStudent] = role;
                    StudentsList.RemoveStudentAt(index);

                    // Display selection
                    Console.Clear();
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("          ¡Seleccionado!                  ");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"¡Hola {selectedStudent}!");
                    Console.WriteLine($"Eres seleccionado como {role}.");
                    Console.WriteLine("----------------------------------------");





                    // Gentle animation
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("          ¡Seleccionado!                  ");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"¡Hola {selectedStudent}!");
                    Console.WriteLine($"Eres seleccionado como {role}.");
                    Console.WriteLine("----------------------------------------");

                    Thread.Sleep(500);
                    Console.Clear();

                    // Display final selection
                    Console.WriteLine("════════════════════════════════════════");
                    Console.WriteLine("          ¡Seleccionado!                  ");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"¡Hola {selectedStudent}!");
                    Console.WriteLine($"Eres seleccionado como {role}.");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();

                    return selectedStudent;
                }

                randomIndex++;
                attempts++;
            }

            return "NO_STUDENTS_AVAILABLE";
        }

        public static void ProgramExecution()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Programa finalizado.");

            StudentsList.AssignedRoles.Clear();
            StudentsList.ResetAllStudents();
            UserAssignedRoles = false;
        }
    }
}
