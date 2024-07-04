using System;

namespace StudentsSelector
{
    class GetRidStudents
    {
        public static void DeleteStudents()
        {
            string[] Students = StudentsList.AllStudents;

            Console.Write("Ingresa el nombre del estudiante a eliminar: ");
            string? UserSelection = Console.ReadLine();

            if (!string.IsNullOrEmpty(UserSelection))
            {
                bool studentDeleted = false;

                for (int i = 0; i < StudentsList.GetStudentCount(); i++)
                {
                    if (!string.IsNullOrEmpty(Students[i]) && Students[i].IndexOf(UserSelection, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        StudentsList.RemoveStudentAt(i);
                        studentDeleted = true;
                        i--; 
                    }
                }

                if (studentDeleted)
                {
                    Console.WriteLine("Updated list of students:");
                    foreach (string student in StudentsList.AllStudents)
                    {
                        if (!string.IsNullOrEmpty(student)) 
                        {
                            Console.WriteLine(student);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No students found matching the input.");
                }
            }
            else
            {
                Console.WriteLine("Input was null or empty. Please enter a valid part of the student's name.");
            }
        }
    }
}
