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
        public static void ExportGroups(params GroupOfTasks[] groupOfTasks)
        {
            using (FileStream fileStream = new FileStream("exportGroups.dat", FileMode.OpenOrCreate))
            {
                BinarySerializer serializer = new BinarySerializer();
                var input = serializer.Serialize(groupOfTasks);
                fileStream.Write(input);
                Console.WriteLine("Export completed");
            }
        }

        public static void ExportTasks(params Task[] tasks)
        {
            using (FileStream fileStream = new FileStream("exportTasks.dat", FileMode.OpenOrCreate))
            {
                BinarySerializer serializer = new BinarySerializer();
                var input = serializer.Serialize(tasks);
                fileStream.Write(input);
                Console.WriteLine("Export completed");
            }
        }

        public static GroupOfTasks[] ImportGroups()
        {
            BinarySerializer serializer = new BinarySerializer();
            var import = File.ReadAllBytes("exportGroups.dat");
            
            var importData = serializer.Deserialize<GroupOfTasks[]>(import);
            Console.WriteLine("Import completed");
            return importData;
        }

        public static GroupOfTasks[] ImportTasks()
        {
            BinarySerializer serializer = new BinarySerializer();
            var import = File.ReadAllBytes("exportTasks.dat");

            var importData = serializer.Deserialize<GroupOfTasks[]>(import);
            Console.WriteLine("Import completed");
            return importData;
        }
    }
}
