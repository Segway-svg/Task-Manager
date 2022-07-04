using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class ConsoleInputOutput
    {
        public static void Begin()
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("Enter the command:\n" +
                                  "1) create task\n" +
                                  "2) create group\n" +
                                  "3) add task to group\n" +
                                  "4) add subtask\n" +
                                  "5) add deadline\n" +
                                  "6) change status\n" +

                                  "7) show all tasks need to complete today\n" +
                                  "8) show all completed tasks\n" +
                                  "9) show all tasks\n" +
                                  "10) show subtasks\n" +
                                  "11) show all subtasks\n" +
                                  "12) show task\n" +
                                  "13) show group\n" +
                                  "14) show all groups and its info\n" +

                                  "15) delete group\n" +
                                  "16) delete task\n" +
                                  "17) delete task from group\n" +

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
                        AddTaskToGroup(taskManager);
                        break;
                    case "4":
                        AddSubtask(taskManager);
                        break;
                    case "5":
                        AddDeadline(taskManager);
                        break;
                    case "6":
                        AddDoneStatus(taskManager);
                        break;
                    case "7":
                        ShowTasksNeedToCompleteToday(taskManager);
                        break;
                    case "8":
                        GetAllCompletedTasks(taskManager);
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
                        ShowAllGroupsAndItsInfo(taskManager);
                        break;
                    case "15":
                        DeleteGroup(taskManager);
                        break;
                    case "16":
                        DeleteTask(taskManager);
                        break;
                    case "17":
                        DeleteTaskFromGroup(taskManager);
                        break;
                    case "18":
                        return;
                    default:
                        Console.WriteLine("wrong command\n");
                        break;
                }
            }
        }

        public static int GetId()
        {
            int num = 0;
            string id = "";
            while (true)
            {
                id = Console.ReadLine();
                if (int.TryParse(id, out var number))
                {
                    num = int.Parse(id);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, try again");
                }
            }
            return num;
        }

        public static void CreateTask(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the task id and info:");
            Console.Write("id: ");
            int id = GetId();
            Console.Write("info: ");
            string info = Console.ReadLine();
            taskManager.CreateTask(new Task(id, info));
            Console.WriteLine();
        }

        public static void AddGroup(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the group name and info:");
            Console.Write("id: ");
            int id = GetId();
            Console.Write("info: ");
            string name = Console.ReadLine();
            taskManager.AddGroup(new GroupOfTasks(id, name));
            Console.WriteLine();
        }

        public static void AddTaskToGroup(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            taskManager.AddSubtask(GetId());
            Console.WriteLine();
        }

        public static void AddSubtask(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            taskManager.AddSubtask(GetId());
            Console.WriteLine();
        }

        public static void AddDeadline(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            taskManager.AddDeadline(GetId());
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
            taskManager.AddDoneStatus(GetId(), type);
            Console.WriteLine();
        }

        public static void ShowTasksNeedToCompleteToday(TaskManager taskManager)
        {
            taskManager.ShowTasksNeedToCompleteToday();
            Console.WriteLine();
        }

        public static void GetAllCompletedTasks(TaskManager taskManager)
        {
            taskManager.GetAllCompletedTasks();
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
            taskManager.ShowSubtasks(GetId());
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
            taskManager.ShowTask(GetId());
            Console.WriteLine();
        }

        public static void ShowGroup(TaskManager taskManager)
        {
            Console.WriteLine("\nEnter the group id:");
            Console.Write("id: ");
            taskManager.ShowGroup(GetId());
            Console.WriteLine();
        }

        public static void ShowAllGroupsAndItsInfo(TaskManager taskManager)
        {
            taskManager.ShowAllGroupsAndItsInfo();
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
            taskManager.DeleteTask(GetId());
            Console.WriteLine();
        }

        public static void DeleteTaskFromGroup(TaskManager taskManager)
        {
            Console.WriteLine("Enter the task id:");
            Console.Write("id:");
            int taskId = GetId();
            Console.WriteLine("Enter the group id:");
            Console.Write("id:");
            int groupId = GetId();
            taskManager.DeleteTaskFromGroup(groupId, taskId);
            Console.WriteLine();
        }
    }
}
