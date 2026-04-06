using TMP_Laba3_Libraries.Authorization;

namespace TMP_Laba3
{
    public class Seeker
    {
        public Person? Seek(string name, string password, List<Person> users)
        {
            foreach (var user in users)
            {
                if (name == user.Name && password == user.Password)
                    return user;
            }
            return null;
        }
    }
}
