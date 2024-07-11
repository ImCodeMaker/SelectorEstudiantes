using System;
using System.Threading;

namespace StudentsSelector
{
    public static class ProgramStudents
    {
        private static string? Role;
        private static string? Role2;
        private static bool UserAssignedRoles = false;
        private static Random random = new Random(); // Generador aleatorio único

        public static void Init()
        {
            bool programRunning = true;

            while (programRunning)
            {
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
                                Console.WriteLine($"{Role} seleccionado: {developer}");
                                Console.WriteLine($"{Role2} seleccionado: {facilitator}");

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

                Console.WriteLine($"¡Hola {selectedStudent}! Eres seleccionado como {role} y te tocará hacer el ejercicio más votado por el público.");
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

                    if (studentCount == 1)
                    {
                        Console.WriteLine($"¡Hola {selectedStudent}! Eres seleccionado como {role} y te tocará hacer el ejercicio más votado por el público.");
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        return "LAST_STUDENT_SELECTED";
                    }

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
