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
        public static void PrintTasks(IEnumerable<Task> tasks, TextWriter writer)
        {
            foreach (var task in tasks)
            {
                PrintTask(task, writer);
            }
        }

        public static void PrintAllSubtasks(List<Subtask> subtasks, TextWriter writer)
        {
            foreach (var subtask in subtasks)
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

        public static void PrintGroups(IEnumerable<GroupOfTasks> groupOfTasks, TextWriter writer)
        {
            foreach (var group in groupOfTasks)
            {
                PrintGroup(group, writer);
            }
        }

        public static void PrintTask(Task task, TextWriter writer)
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

        public static void PrintSubtask(List<Subtask> subtasks, TextWriter writer)
        {
            PrintAllSubtasks(subtasks, Console.Out);
        }

        public static void PrintGroup(GroupOfTasks groupOfTasks, TextWriter writer)
        {
            Console.WriteLine($"Group {groupOfTasks.Name}:");
            foreach (var task in groupOfTasks.GetTasks())
            {
                PrintTask(task, writer);
            }
        }
    }
}
