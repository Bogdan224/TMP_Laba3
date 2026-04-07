using System.IO;
using System.Windows.Documents;

namespace TMP_Laba3_Authorization
{
    public class Seeker
    {
        AssemblyPerson assembly = new AssemblyPerson();

        public Person? Seek(string name, string password, string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 3)
                    continue;

                var _name = parts[0];
                var _password = parts[1];
                var role = parts[2];

                if (name == _name && password == _password)
                    return assembly.Assembly(_name, _password, Convert.ToInt32(role));
            }
            return null;
        }
    }
}
