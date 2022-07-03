using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    [Serializable]
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        private List<GroupOfTasks> groups = new List<GroupOfTasks>();

        public IReadOnlyList<Task> Tasks => tasks;
        public IReadOnlyList<GroupOfTasks> GroupOfTasks => groups;

        public void CreateTask(Task task)
        {
            if (tasks.Count == 0)
            {
                tasks.Add(task);
            }
            else
            {
                var check = true;
                if (tasks.Any(tmp => tmp.Id == task.Id))
                {
                    Console.WriteLine("We have already this task!");
                    check = false;
                }
                if (check)
                {
                    tasks.Add(task);
                }
            }
        }

        public void AddSubtask(int id)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks are empty");
            }
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    Console.WriteLine("\nEnter the subtask id and info:");
                    Console.Write("id: ");
                    int subId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("info: ");
                    string info = Console.ReadLine();
                    task.SubTasks.Add(new Subtask(subId, info));
                }
            }
        }

        public void AddGroup(GroupOfTasks group)
        {
            if (groups.Count == 0)
            {
                groups.Add(group);

            }
            else
            {
                var check = true;
                if (groups.Any(tmp => tmp.Id == group.Id))
                {
                    Console.WriteLine("We have already this group!");
                    check = false;
                }
                if (check)
                {
                    groups.Add(group);
                }
            }
        }

        public void DeleteTask(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id)
                {
                    tasks.RemoveAt(i);
                }
            }

            var forRemoving = new ConcurrentBag<Task>();

            foreach (var group in groups)
            {
                foreach (var task in tasks)
                {
                    if (task.Id == id)
                    {
                        forRemoving.Add(task);
                    }
                }
            }

            foreach (var task in tasks)
            {
                tasks.Remove(task);
            }
        }

        public void DeleteTaskFromGroup(int groupId, int taskId)
        {
            var forRemoving = new ConcurrentBag<Task>();

            foreach (var group in groups)
            {
                if (group.Id == groupId)
                {
                    foreach (var task in tasks)
                    {
                        forRemoving.Add(task);
                    }
                }
            }

            foreach (var task in tasks)
            {
                tasks.Remove(task);
            }
        }

        public void DeleteGroup(int id)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Id == id)
                {
                    groups.RemoveAt(i);
                }
            }
        }

        public void ShowAllGroupsAndItsInfo()
        {
            Console.WriteLine("All groups and their info:");
            foreach (var group in groups)
            {
                Console.WriteLine(group.Name);
                if (tasks.Count == 0)
                {
                    Console.WriteLine("no tasks");
                }
                else
                {
                    TasksPrinter.PrintTasks(tasks, Console.Out);
                }
            }
        }

        public void ShowAllTasks()
        {
            Console.WriteLine("All tasks:");
            TasksPrinter.PrintTasks(tasks, Console.Out);
        }

        public void ShowTask(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    TasksPrinter.PrintTask(task, Console.Out);
                }
            }
        }

        public void ShowSubtasks(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    TasksPrinter.PrintSubtask(task.SubTasks, Console.Out);
                }
            }
        }

        public void ShowAllSubtasks()
        {
            foreach (var task in tasks)
            {
                TasksPrinter.PrintAllSubtasks(task.SubTasks, Console.Out);
            }
        }

        public void ShowGroup(int id)
        {
            foreach (var group in groups)
            {
                if (group.Id == id)
                {
                    TasksPrinter.PrintGroup(group, Console.Out);
                }
            }
        }

        public void GetAllCompletedTasks()
        {
            Console.WriteLine("Completed tasks:");
            TasksPrinter.PrintTasks(tasks.Where(task => task.IsDone == true), Console.Out);
        }

        public void AddDoneStatus(int id, string type)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("tasks are empty");
            }
            if (type == "task")
            {
                foreach (var task in tasks)
                {
                    if (task.Id == id)
                    {
                        if (!task.IsDone)
                        {
                            task.IsDone = true;
                        }
                        else
                        {
                            task.IsDone = false;
                        }
                    }
                }
            }
            else if (type == "subtask")
            {
                foreach (var task in tasks)
                {
                    foreach (var subtask in task.SubTasks)
                    {
                        if (subtask.Id == id)
                        {
                            if (!subtask.IsDone)
                            {
                                subtask.IsDone = true;
                            }
                            else
                            {
                                subtask.IsDone = false;
                            }
                        }
                    }
                }
            }
        }

        public void AddDeadline(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    DateTime dob; // date of birth
                    string input;
                    do
                    {
                        Console.WriteLine("Enter the date дд.ММ.гггг (day.month.year):");
                        input = Console.ReadLine();
                    }
                    while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));
                    task.Deadline = dob;
                }
            }
        }

        public void ShowTasksNeedToCompleteToday()
        {
            Console.WriteLine("Tasks need to complete today");
            TasksPrinter.PrintTasks(tasks.Where(task => task.Deadline.Date == DateTime.Today.Date), Console.Out);
        }
    }
}

