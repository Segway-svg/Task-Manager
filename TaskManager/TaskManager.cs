using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    [Serializable]
    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        private List<GroupOfTasks> groups = new List<GroupOfTasks>();

        public IReadOnlyList<Task> Tasks => tasks;

        public void AddTask(Task task)
        {
            if (!tasks.Contains(task))
            {
                tasks.Add(task);
            }
            else
            {
                Console.WriteLine("We already have this task!");
            }
        }

        public void AddGroup(GroupOfTasks group)
        {
            foreach (var task in group.GetTasks())
            {
                AddTask(task);
            }
            groups.Add(group);
        }

        public void DeleteGroup(GroupOfTasks group)
        {
            groups.Remove(group);
        }

        public void ShowAllGroupsAndItsInfo()
        {
            Console.WriteLine("All groups and their info:");
            foreach (var group in groups)
            {
                Console.WriteLine(group.Name);
                foreach (var task in group.GetTasks())
                {
                    task.ShowTask();
                }
            }
            Console.WriteLine();
        }

        public void ShowAllTasks()
        {
            Console.WriteLine("All tasks:");
            foreach (var task in tasks)
            {
                task.ShowTask();
            }
            Console.WriteLine();
        }

        public void GetAllCompletedTasks()
        {
            Console.WriteLine("Completed tasks:");
            foreach (var task in tasks)
            {
                if (task.IsDone)
                {
                    task.ShowTask();
                }
            }
            Console.WriteLine();
        }

        public void AddDoneStatus(int id)
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

        public void AddDeadline(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    task.Deadline = DateTime.Now;
                }
            }
        }

        public void ShowTasksNeedToCompleteToday()
        {
            Console.WriteLine("Tasks need to complete today");
            foreach (var task in tasks)
            {
                if (task.Deadline.Date == DateTime.Today.Date)
                {
                    task.ShowTask();
                }
            }
            Console.WriteLine();
        }
    }
}