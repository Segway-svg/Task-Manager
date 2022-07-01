using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class TasksPrinter
    {
        public static void PrintTask(IReadOnlyCollection<Task> tasks, TextWriter writer)
        {
            foreach (var task in tasks)
            {
                PrintTask(task, writer);
            }
        }

        public static void PrintGroup(IReadOnlyCollection<GroupOfTasks> groupOfTasks, TextWriter writer)
        {
            foreach (var group in groupOfTasks)
            {
                Console.WriteLine($"Group {group.Name}:");
                foreach (var task in group.GetTasks())
                { 
                    PrintTask(task, writer);
                }
            }
            Console.WriteLine();
        }

        private static void PrintTask(Task task, TextWriter writer)
        {
            string deadlineStr = "";

            if (task.Deadline != DateTime.MinValue)
            {
                deadlineStr = " (" + task.Deadline + ")";
            }
            if (task.IsDone)
            {
                writer.WriteLine($"[x]{deadlineStr} {{{task.Id}}} {task.Info}");
            }
            else
            {
                writer.WriteLine($"[ ]{deadlineStr} {{{task.Id}}} {task.Info}");
            }

            foreach (var subtask in task.SubTasks)
            {
                if (subtask.IsDone)
                {
                    writer.WriteLine($"- [x] {{{subtask.Id}}} {subtask.Info}");
                }
                else
                {
                    writer.WriteLine($"- [ ] {{{subtask.Id}}} {subtask.Info}");
                }
            }
        }

        public static void Print(IReadOnlyCollection<GroupOfTasks> groupsOfTasks)
        {

        }
    }
}
