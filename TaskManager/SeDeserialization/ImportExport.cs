using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TaskManager.SeDeserialization
{
    public static class ImportExport
    {
        public static void ImportGroups(params GroupOfTasks[] groupOfTasks)
        {
            // Сохранение в файл группы (включая задачи и подзадачи)

            using (FileStream fileStream = new FileStream("importGroups.dat", FileMode.OpenOrCreate))
            {
                BinarySerializer serializer = new BinarySerializer();
                var input = serializer.Serialize(groupOfTasks);
                fileStream.Write(input);
                Console.WriteLine("Import completed");
            }
        }

        public static void ImportTasks(params Task[] tasks)
        {
            using (FileStream fileStream = new FileStream("importTasks.dat", FileMode.OpenOrCreate))
            {
                BinarySerializer serializer = new BinarySerializer();
                var input = serializer.Serialize(tasks);
                fileStream.Write(input);
                Console.WriteLine("Import completed");
            }
        }

        public static void ExportGroups()
        {
            // Экспорт групп из файла

            BinarySerializer serializer = new BinarySerializer();
            var export = File.ReadAllBytes("importGroups.dat");
            
            var exportData = serializer.Deserialize<GroupOfTasks[]>(export);
            Console.WriteLine("Export completed");
        }

        public static void ExportTasks()
        {
            // Экспорт задач из файла
            BinarySerializer serializer = new BinarySerializer();
            var export = File.ReadAllBytes("importTasks.dat");

            var exportData = serializer.Deserialize<GroupOfTasks[]>(export);
            Console.WriteLine("Export completed");
        }
    }
}
