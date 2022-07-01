using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TaskManager
{
    [Serializable]
    public class Task
    {
        public int Id { get; private set; }

        public string Info { get; private set; }
        
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
        public List<Subtask> SubTasks { get; private set; } = new List<Subtask>();

        public Task(int id, string info)
        {
            Id = id;
            Info = info;
        }

        public void CreateSubtask(int id, string info)
        {
            SubTasks.Add(new Subtask(id, info));
        }

        public void ShowTask()
        {
            string deadlineStr = "";

            if (Deadline != DateTime.MinValue)
            {
                deadlineStr = " (" + Deadline + ")";
            }
            if (IsDone)
            {
                Console.WriteLine($"[x]{deadlineStr} {{{Id}}} {Info}");
            }
            else
            {
                Console.WriteLine($"[ ]{deadlineStr} {{{Id}}} {Info}");
            }

            foreach (var subtask in SubTasks)
            {
                if (subtask.IsDone)
                {
                    Console.WriteLine($"- [x]" + " {" + subtask.Id + "} " + subtask.Info);
                }
                else
                {
                    Console.WriteLine($"- [ ]" + " {" + subtask.Id + "} " + subtask.Info);
                }
            }
        }
    }
}