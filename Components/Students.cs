using System;
using System.Collections.Generic;

namespace StudentsSelector
{
    public static class StudentsList
    {
        private static string[] allStudents = Array.Empty<string>(); // Initialize with an empty array
        private static int studentCount;

        public static string[] AllStudents => allStudents;

        public static Dictionary<string, string> AssignedRoles { get; set; }

        static StudentsList()
        {
            AssignedRoles = new Dictionary<string, string>();
            ResetAllStudents();
        }

        public static void ResetAllStudents()
        {
            allStudents = new string[]
            {
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

            studentCount = allStudents.Length;
        }

        public static void ResizeArray()
        {
            string[] newArray = new string[allStudents.Length + 1];
            Array.Copy(allStudents, newArray, allStudents.Length);
            allStudents = newArray;
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
                allStudents[i] = allStudents[i + 1];
            }

            allStudents[studentCount - 1] = string.Empty;
            studentCount--;
        }

        public static int GetStudentCount()
        {
            return studentCount;
        }
    }
}
