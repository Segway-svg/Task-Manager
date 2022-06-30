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
        public List<Task> tasks = new List<Task>();

        // Создание группы для задач
        public GroupOfTasks(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Добавление задачи в группу
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        // Удаление задачи
        public void DeleteTask(int id)
        {
            tasks.Remove(tasks[id]);
        }


        // Удаление задачи из группы
        public void DeleteTaskFromGroup(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id)
                {
                    tasks.Remove(tasks[i]);
                }
            }
        }

        // Получение списка групп с добавленными задачами
        public IReadOnlyList<Task> GetGroup()
        {
            return tasks;
        }


        // Просмотр всех задач и подзадач группы
        public void ShowGroup()
        {
            Console.WriteLine($"Group {Name}:");
            foreach (var task in tasks)
            {
                task.ShowTask();
            }
            Console.WriteLine();
        }
    }
}
