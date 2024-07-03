using System;

namespace StudentsSelector
{
    public class AddStudents
    {
        public static void AddStudent()
        {
            string[] Students = StudentsList.AllStudents;

            Console.WriteLine("Ingrese el nombre del estudiante a añadir:");
            string? UserSelection = Console.ReadLine();

            if (!string.IsNullOrEmpty(UserSelection))
            {
                // Check if the student already exists
                bool studentExists = Array.Exists(Students, student => student == UserSelection);

                if (studentExists)
                {
                    Console.WriteLine($"El estudiante '{UserSelection}' ya existe.");
                }
                else
                {
                    // Find the first empty slot in the array
                    int index = Array.IndexOf(Students, string.Empty);

                    if (index != -1)
                    {
<<<<<<< HEAD
                        StudentsList.AllStudents[index] = UserSelection;
=======
                        Students[index] = UserSelection;
>>>>>>> bf368a8ab4ab6dd515e5ac33feffe32a8900488b
                        Console.WriteLine($"Estudiante '{UserSelection}' añadido exitosamente.");
                    }
                    else
                    {
                        StudentsList.ResizeArray();
                        StudentsList.AllStudents[StudentsList.GetStudentCount() - 1] = UserSelection; // Use the last slot in the resized array
                        Console.WriteLine($"Estudiante '{UserSelection}' añadido exitosamente.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. El nombre del estudiante no puede estar vacío.");
            }
        }
    }
}
