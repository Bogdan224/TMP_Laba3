using System.IO;
using TMP_Laba3_Libraries.Authorization;

namespace TMP_Laba3
{
    public class FileReader
    {
        public List<Person> Read(string path)
        {
            var list = new List<Person>();

            if (!File.Exists(path))
                throw new FileNotFoundException();

            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 3)
                    continue;

                list.Add(new Person(parts[0], parts[1], parts[2]));
            }

            return list;
        }
    }
}
