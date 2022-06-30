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
        // Возможность отметить подзадачу выполненной
        public bool IsDone { get; set; }

        // Добавление подзадачи к задаче
        public Subtask(int id, string info)
        {
            Id = id;
            Info = info;
        }

        //Отображение подзадачи
        public void ShowSubtask()
        {
            if (IsDone)
            {
                Console.WriteLine($"- [ ] {Id} {Info}");
            }
            else
            {
                Console.WriteLine($"- [x] {Id} {Info}");
            }
        }
    }
}
