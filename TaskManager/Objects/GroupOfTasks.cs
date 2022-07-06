using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskManager
{
    [Serializable]
    public class GroupOfTasks
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private List<Task> tasks = new List<Task>();

        public GroupOfTasks(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public IReadOnlyList<Task> GetTasks()
        {
            return tasks;
        }
    }
}