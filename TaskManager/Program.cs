using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using TaskManager.SeDeserialization;
using Console = System.Console;

namespace TaskManager
{
    public class Program
    {
        public static void CreateTask(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the task id and info:");
            Console.Write("id: ");
            //TODO try parse
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("info: ");
            string info = Console.ReadLine();
            taskManager.CreateTask(new Task(id, info));
            Console.WriteLine();
        }

        public static void AddGroup(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the group name and info:");
            Console.Write("id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("info: ");
            string name = Console.ReadLine();
            taskManager.AddGroup(new GroupOfTasks(id, name));
            Console.WriteLine();
        }

        public static void AddTaskToGroup(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.AddSubtask(id);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void AddSubtask(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.AddSubtask(id);
            Console.WriteLine();
        }

        public static void DeleteGroup(TaskManager taskManager)
        {
            Console.WriteLine("Enter the group id:");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.DeleteGroup(id);
            Console.WriteLine();
        }

        public static void DeleteTask(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            Console.Write("id:");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.DeleteTask(id);
            Console.WriteLine();
        }

        public static void DeleteTaskFromGroup(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            Console.Write("id:");
            int taskId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the grouo id:");
            Console.Write("id:");
            int groupId = Convert.ToInt32(Console.ReadLine());
            taskManager.DeleteTaskFromGroup(groupId, taskId);
            Console.WriteLine();
        }

        public static void ShowAllGroupsAndItsInfo(TaskManager taskManager)
        {
            taskManager.ShowAllGroupsAndItsInfo();
            Console.WriteLine();
        }

        public static void ShowAllTasks(TaskManager taskManager)
        {
            taskManager.ShowAllTasks();
            Console.WriteLine();
        }

        public static void ShowSubtasks(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the task id:");
            Console.Write("id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.ShowSubtasks(id);
            Console.WriteLine();
        }

        public static void ShowAllSubtasks(TaskManager taskManager)
        {
            taskManager.ShowAllSubtasks();
            Console.WriteLine();
        }

        
        public static void ShowTask(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the task id:");
            Console.Write("id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.ShowTask(id);
            Console.WriteLine();
        }

        public static void ShowGroup(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the group id:");
            Console.Write("id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.ShowGroup(id);
            Console.WriteLine();
        }


        public static void GetAllCompletedTasks(TaskManager taskManager)
        {
            taskManager.GetAllCompletedTasks();
            Console.WriteLine();
        }

        public static void AddDoneStatus(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the type (task/subtask):");
            string type = "";
            while (true)
            {
                Console.Write("type: ");
                type = Console.ReadLine();
                if (type != "task" && type != "subtask")
                {
                    Console.WriteLine("incorrect type, try again\n");
                }
                else
                {
                    break;
                }
            }

            Console.Write("id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.AddDoneStatus(id, type);
            Console.WriteLine();
        }

        public static void AddDeadline(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            taskManager.AddDeadline(id);
            Console.WriteLine();
        }

        public static void ShowTasksNeedToCompleteToday(TaskManager taskManager)
        {
            taskManager.ShowTasksNeedToCompleteToday();
            Console.WriteLine();
        }



        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("Enter the command:\n" +
                                  "1) create task\n" +
                                  "2) create group\n" +
                                  "3) delete group\n" +
                                  "4) show all groups and its info\n" +
                                  "5) show all completed tasks\n" +
                                  "6) show all tasks need to complete today\n" +
                                  "7) change status\n" +
                                  "8) add deadline\n" +
                                  "9) show all tasks\n" +
                                  "10) show subtasks\n" +
                                  "11) show all subtasks\n" +
                                  "12) show task\n" +
                                  "13) show group\n" +
                                  "14) add task to group\n" +
                                  "15) add subtask\n" +
                                  "16) delete group\n" +
                                  "17) delete task\n" +
                                  "18) delete task from group\n" +
                                  "19) exit\n");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        CreateTask(taskManager);
                        break;
                    case "2":
                        AddGroup(taskManager);
                        break;
                    case "3":
                        DeleteGroup(taskManager);
                        break;
                    case "4":
                        ShowAllGroupsAndItsInfo(taskManager);
                        break;
                    case "5":
                        GetAllCompletedTasks(taskManager);
                        break;
                    case "6":
                        ShowTasksNeedToCompleteToday(taskManager);
                        break;
                    case "7":
                        AddDoneStatus(taskManager);
                        break;
                    case "8":
                        AddDeadline(taskManager);
                        break;
                    case "9":
                        ShowAllTasks(taskManager);
                        break;
                    case "10":
                        ShowSubtasks(taskManager);
                        break;
                    case "11":
                        ShowAllSubtasks(taskManager);
                        break;
                    case "12":
                        ShowTask(taskManager);
                        break;
                    case "13":
                        ShowGroup(taskManager);
                        break;
                    case "14":
                        AddTaskToGroup(taskManager);
                        break;
                    case "15":
                        AddSubtask(taskManager);
                        break;
                    case "16":
                        DeleteGroup(taskManager);
                        break;
                    case "17":
                        DeleteTask(taskManager);
                        break;
                    case "18":
                        DeleteTaskFromGroup(taskManager);
                        break;
                    case "19":
                        return;
                    default:
                        Console.WriteLine("wrong command\n");
                        break;
                }
            }


            //var taskManager = new TaskManager();

            //Task task1 = new Task(1, "task1");
            //task1.CreateSubtask(1, "subtask1.1");
            //task1.CreateSubtask(1, "subtask1.2");
            //task1.Deadline = DateTime.Today;

            //Task task2 = new Task(2, "task2");
            //task2.CreateSubtask(2, "subtask2.1");
            //task2.CreateSubtask(2, "subtask2.2");
            //task2.Deadline = new DateTime(2022, 7, 4, 22, 00, 0);

            //Task task3 = new Task(3, "task3");
            //task3.CreateSubtask(3, "subtask3.1");
            //task3.CreateSubtask(3, "subtask3.2");
            //task3.Deadline = DateTime.Now;


            //Task taskToDel = new Task(0, "task0");
            //taskToDel.CreateSubtask(0, "subtask0.1");
            //taskToDel.CreateSubtask(0, "subtask0.2");

            //GroupOfTasks groupOfTasks1 = new GroupOfTasks(1, "group1");
            //groupOfTasks1.AddTask(task1);
            //groupOfTasks1.AddTask(task2);
            //groupOfTasks1.AddTask(task3);

            //groupOfTasks1.DeleteTaskFromGroup(0);
            //TasksPrinter.PrintGroup(groupOfTasks1, Console.Out);

            //Task task4 = new Task(4, "task4");
            //task4.CreateSubtask(4, "subtask4.1");
            //task4.CreateSubtask(4, "subtask4.2");

            //Task task5 = new Task(5, "task5");
            //task5.CreateSubtask(5, "subtask5.1");
            //task5.CreateSubtask(5, "subtask5.2");

            //Task task6 = new Task(6, "task6");
            //task6.CreateSubtask(6, "subtask6.1");
            //task6.CreateSubtask(6, "subtask6.2");

            //GroupOfTasks groupOfTasks2 = new GroupOfTasks(2, "group2");
            //groupOfTasks2.AddTask(task4);
            //groupOfTasks2.AddTask(task5);
            //groupOfTasks2.AddTask(task6);

            //groupOfTasks2.DeleteTaskFromGroup(6);
            //TasksPrinter.PrintGroup(groupOfTasks2, Console.Out);

            //taskManager.AddGroup(groupOfTasks1);
            //taskManager.AddGroup(groupOfTasks2);

            //taskManager.ShowAllGroupsAndItsInfo();

            //taskManager.ShowAllTasks();

            //taskManager.AddDoneStatus(4);
            //taskManager.AddDeadline(4);
            //taskManager.GetAllCompletedTasks();

            //taskManager.ShowTasksNeedToCompleteToday();

            //ImportExport.ExportGroups(groupOfTasks1, groupOfTasks2);
            //var deserializedData = ImportExport.ImportGroups();


            //TasksPrinter.PrintTasks(taskManager.Tasks, Console.Out);
            //TasksPrinter.PrintGroups(taskManager.GroupOfTasks, Console.Out);
        }
    }
}