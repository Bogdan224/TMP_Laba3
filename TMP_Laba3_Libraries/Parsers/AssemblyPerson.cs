using TMP_Laba3_Libraries.Authorization;

namespace TMP_Laba3
{
    public class AssemblyPerson
    {
        public Person Assembly(string name, string password, string role)
        {
            return new Person(name, password, role);
        }
    }
}
