using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.SeDeserialization
{
    internal class ImportExport
    {
        public static void Import(GroupOfTasks groupOfTasks)
        {
            // Сохранение в файл задачи (включая группы и подзадачи)
            using (FileStream fileStream = new FileStream("import.dat", FileMode.OpenOrCreate))
            {
                BinarySerializer serializer = new BinarySerializer();
                var input = serializer.Serialize(groupOfTasks);
                //byte[] input = Encoding.Default.GetBytes(text);

                fileStream.Write(input, 0, input.Length);
                Console.WriteLine("Import completed");
            }
        }

        public static void Export()
        {

            BinarySerializer serializer = new BinarySerializer();
            var export = File.ReadAllBytes("import.dat");

            var exportData = serializer.Deserialize<GroupOfTasks>(export);

            // Создаём новый репозиторий для хранения окончательных данных
            //var destinationRepository = new VolatileRepository();
            //satellitesMemo2.UnpackInto(destinationRepository);
            Console.WriteLine("Export completed");
        }
    }
}
