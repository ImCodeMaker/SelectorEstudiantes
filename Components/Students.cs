using System;
using System.Collections.Generic;

namespace StudentsSelector
{
    public static class StudentsList
    {
        public static string[] AllStudents { get; private set; }
        private static int studentCount;

        
        public static Dictionary<string, string> AssignedRoles { get; set; }

        
        static StudentsList()
        {
            AssignedRoles = new Dictionary<string, string>();

            AllStudents = new string[]
            {
                // List of initial students
                "Alex Jose Rodriguez Taveras",
                "Amaury Daniel Romero Gonzalez",
                "Ashlee Ramirez Rosario",
                "Cyd Marie Jorge Chapman",
                "Edison Yadir Rossis",
                "Edwin Oscar Perez Rodriguez",
                "Eli Samuel Suero Rodriguez",
                "Erickson David Encarnacion Encarnacion",
                "Eudy Yunior Lorenzo Ramirez",
                "Jamil Guzman Feliz",
                "Joan Manuel Arroyo Valerio",
                "Jose Miguel Canela Santos",
                "Maria Del Carmen Diaz Campanas",
                "Maria Marlene Abreu Saiz",
                "Marlon Miguel Vargas Mendez",
                "Michael Dmeshell Sanchez Heredia",
                "Odana Margarita Calderon Pache",
                "Oscar Daniel Tuletta Mercedes",
                "Rafael Antonio Urbaez Hernandez",
                "Smith Morillo Encarnacion",
                "Teudy Joshua Encarnacion Fulgencio",
                "Xander Ruddy Cruz De La Rosa",
                "Yadianna Vargas Pimentel",
                "Yafreisy Emelin Alvarez Capellan",
                "Yoelmi Alexander Alcala Valdez"
            };

            studentCount = AllStudents.Length;
        }

        
        public static void ResetAllStudents()
        {
            AllStudents = new string[]
            {
                // Reset the list of students
                "Alex Jose Rodriguez Taveras",
                "Amaury Daniel Romero Gonzalez",
                "Ashlee Ramirez Rosario",
                "Cyd Marie Jorge Chapman",
                "Edison Yadir Rossis",
                "Edwin Oscar Perez Rodriguez",
                "Eli Samuel Suero Rodriguez",
                "Erickson David Encarnacion Encarnacion",
                "Eudy Yunior Lorenzo Ramirez",
                "Jamil Guzman Feliz",
                "Joan Manuel Arroyo Valerio",
                "Jose Miguel Canela Santos",
                "Maria Del Carmen Diaz Campanas",
                "Maria Marlene Abreu Saiz",
                "Marlon Miguel Vargas Mendez",
                "Michael Dmeshell Sanchez Heredia",
                "Odana Margarita Calderon Pache",
                "Oscar Daniel Tuletta Mercedes",
                "Rafael Antonio Urbaez Hernandez",
                "Smith Morillo Encarnacion",
                "Teudy Joshua Encarnacion Fulgencio",
                "Xander Ruddy Cruz De La Rosa",
                "Yadianna Vargas Pimentel",
                "Yafreisy Emelin Alvarez Capellan",
                "Yoelmi Alexander Alcala Valdez"
            };

            studentCount = AllStudents.Length;
        }

        public static void ResizeArray()
        {
            
            string[] newArray = new string[AllStudents.Length + 1];
            Array.Copy(AllStudents, newArray, AllStudents.Length);
            AllStudents = newArray;
            studentCount++;
        }

       
        public static void RemoveStudentAt(int index)
        {
            if (index < 0 || index >= studentCount)
            {
                throw new IndexOutOfRangeException("El indice esta fuera de rango.");
            }

           
            for (int i = index; i < studentCount - 1; i++)
            {
                AllStudents[i] = AllStudents[i + 1];
            }

            
            AllStudents[studentCount - 1] = string.Empty;
            studentCount--;
        }

        
        public static int GetStudentCount()
        {
            return studentCount;
        }
    }
}
