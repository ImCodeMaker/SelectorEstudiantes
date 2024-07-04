using System;

namespace StudentsSelector
{
    public static class MainMenu
    {
        public static void StartMenu(string userName)
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Iniciar el juego");
            Console.WriteLine("2. Ver la lista de Estudiantes");
            Console.WriteLine("3. Eliminar un Estudiante");
            Console.WriteLine("4. Agregar un Estudiante");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}
