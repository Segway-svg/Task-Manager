using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    [Serializable]
    public class Subtask
    {
        public int Id { get; private set; }
        public string Info { get; private set; }
        
        public bool IsDone { get; set; }

        public Subtask(int id, string info)
        {
            Id = id;
            Info = info;
        }
    }
}