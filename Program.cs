using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            
            int selectedMenu = 0;
            do
            {
                selectedMenu = ShowMainMenu();
                if ((Menu)selectedMenu == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)selectedMenu == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)selectedMenu == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)selectedMenu != Menu.Exit);
        }
        /// <summary>
        /// Show the option for task. 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            
            string selectedOption = Console.ReadLine();
            return Convert.ToInt32(selectedOption);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                if (TaskList.Count > 0)
                {
                    Console.WriteLine("Ingrese el número de la tarea a remover: ");
                    
                    ShowCurrentTaskList();

                    string taskNumberToRemove = Console.ReadLine();
                    // Remove one position because the array starts in 0.
                    int indexToRemove = Convert.ToInt32(taskNumberToRemove) - 1;
                    if (indexToRemove >= 0 && indexToRemove < TaskList.Count)
                    {
                        string removedTask = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {removedTask} eliminada");

                    } else
                    {
                        Console.WriteLine("No existe esa tarea a eliminar.");
                    }
                }
                else
                {
                    Console.WriteLine("No hay tareas por realizar");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No existe esa tarea a eliminar.");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error inesperado al intentar ingresar la tarea.");
            }
        }

        public static void ShowMenuTaskList()
        {
            ShowCurrentTaskList();
        }

        public static void ShowCurrentTaskList()
        {
            if (TaskList?.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                Console.WriteLine("----------------------------------------");

                int indexTask = 1;
                TaskList.ForEach(p => Console.WriteLine((indexTask++) + ". " + p));

     
                Console.WriteLine("----------------------------------------");
            }

        }

        enum Menu
        {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }
    }
}
