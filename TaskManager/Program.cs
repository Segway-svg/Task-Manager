using System;
using System.Text;
using System.Threading.Channels;
using TaskManager.SeDeserialization;

namespace TaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the command:");

            var taskManager = new TaskManager();

            Task task1 = new Task(1, "task1");
            task1.CreateSubtask(1, "subtask1.1");
            task1.CreateSubtask(1, "subtask1.2");
            task1.Deadline = DateTime.Today;

            Task task2 = new Task(2, "task2");
            task2.CreateSubtask(2, "subtask2.1");
            task2.CreateSubtask(2, "subtask2.2");
            task2.Deadline = new DateTime(2022, 7, 4, 22, 00, 0);

            Task task3 = new Task(3, "task3");
            task3.CreateSubtask(3, "subtask3.1");
            task3.CreateSubtask(3, "subtask3.2");
            task3.Deadline = DateTime.Now;


            Task taskToDel = new Task(0, "task0");
            taskToDel.CreateSubtask(0, "subtask0.1");
            taskToDel.CreateSubtask(0, "subtask0.2");

            GroupOfTasks groupOfTasks1 = new GroupOfTasks(1, "group1");
            groupOfTasks1.AddTask(task1);
            groupOfTasks1.AddTask(task2);
            groupOfTasks1.AddTask(task3);

            groupOfTasks1.DeleteTaskFromGroup(0);
            groupOfTasks1.ShowGroup();

            Task task4 = new Task(4, "task4");
            task4.CreateSubtask(4, "subtask4.1");
            task4.CreateSubtask(4, "subtask4.2");

            Task task5 = new Task(5, "task5");
            task5.CreateSubtask(5, "subtask5.1");
            task5.CreateSubtask(5, "subtask5.2");

            Task task6 = new Task(6, "task6");
            task6.CreateSubtask(6, "subtask6.1");
            task6.CreateSubtask(6, "subtask6.2");

            GroupOfTasks groupOfTasks2 = new GroupOfTasks(2, "group2");
            groupOfTasks2.AddTask(task4);
            groupOfTasks2.AddTask(task5);
            groupOfTasks2.AddTask(task6);

            groupOfTasks2.DeleteTaskFromGroup(6);
            groupOfTasks2.ShowGroup();

            taskManager.AddGroup(groupOfTasks1);
            taskManager.AddGroup(groupOfTasks2);

            taskManager.ShowAllGroupsAndItsInfo();

            taskManager.ShowAllTasks();

            taskManager.AddDoneStatus(4);
            taskManager.AddDeadline(4);
            taskManager.GetAllCompletedTasks();

            taskManager.ShowTasksNeedToCompleteToday();

            ImportExport.ImportGroups(groupOfTasks1, groupOfTasks2);
            ImportExport.ExportGroups();
        }
    }
}
