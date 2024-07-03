using System;

namespace StudentsSelector
{
    public static class ShowStudents
    {
        public static string[] ShowStudentsF()
        {
            int validCount = 0;

            // Contar los elementos no vacíos en AllStudents
            for (int i = 0; i < StudentsList.AllStudents.Length; i++)
            {
                if (!string.IsNullOrEmpty(StudentsList.AllStudents[i]))
                {
                    validCount++;
                }
            }

            string[] validStudents = new string[validCount];
            int index = 0;

           
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
    }
}
