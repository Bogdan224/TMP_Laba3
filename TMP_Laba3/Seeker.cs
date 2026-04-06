using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP_Laba3
{
    public class Seeker
    {
        public Person Seek(string name, string password, List<Person> users)
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
