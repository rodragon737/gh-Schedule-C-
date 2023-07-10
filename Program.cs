﻿List<string> TaskList = new List<string>();


    int menuSelected = 0;
    do
    {
        menuSelected = ShowMainMenu();
        if ((Menu)menuSelected == Menu.Add)
        {
            ShowMenuAdd();
        }
        else if ((Menu)menuSelected == Menu.Remove)
        {
            ShowMenuRemove();
        }
        else if ((Menu)menuSelected == Menu.List)
        {
            ShowMenuTaskList();
        }
    } while ((Menu)menuSelected != Menu.Exit);
/// <summary>
/// Show the main menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    // Read line
    string line = Console.ReadLine();
    return Convert.ToInt32(line);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        // Show current taks
        ShowList();

        string line = Console.ReadLine();
        // Remove one position
        int indexToRemove = Convert.ToInt32(line) - 1;

        if(indexToRemove > (TaskList.Count -1) || indexToRemove <0)
            Console.WriteLine("El número de tarea no es valido");
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {                 
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Hubo problema al eliminar la trea seleccionada");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskToRemove = Console.ReadLine();
        TaskList.Add(taskToRemove);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
        Console.WriteLine("Error al agregar una nueva tarea, intentelo más tarde");
    }
}

void ShowList()
{
        Console.WriteLine("----------------------------------------");
        var indexTask=1;
        TaskList.ForEach(p=> Console.WriteLine($"{indexTask++} . {p}"));
        Console.WriteLine("----------------------------------------");
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    //if (TaskList == null || TaskList.Count == 0) 
    //reemplazado por el operador null en linea superior y se invierte if & else
    {
        ShowList();
    } 
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}
public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4,
}