namespace TMP_Laba3_Authorization
{
    public class AssemblyPerson
    {
        public Person Assembly(string name, string password, string role)
        {
            return new Person(name, password, role);
        }
    }
}
