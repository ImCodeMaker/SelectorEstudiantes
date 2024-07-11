using System;

namespace StudentsSelector
{
    public class MyClass
    {
        public static void Clear(){
            string MyVar = ProgramStudents.NameFile;
            Excel.ClearExcelFile(MyVar);
        }
    }
}