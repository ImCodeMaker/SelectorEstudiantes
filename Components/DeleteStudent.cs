using System;

namespace StudentsSelector
{
    class GetRidStudents
    {
        public static void DeleteStudents()
        {
            string[] Students = StudentsList.AllStudents;

            Console.Write("Enter the name of the student to delete: ");
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
                        i--; // Adjust index after removal
                    }
                }

                if (studentDeleted)
                {
                    Console.WriteLine("Updated list of students:");
                    foreach (string student in StudentsList.AllStudents)
                    {
                        if (!string.IsNullOrEmpty(student)) // Display only valid names
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
