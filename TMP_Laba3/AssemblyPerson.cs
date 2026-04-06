using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP_Laba3
{
    public class AssemblyPerson
    {
        public Person Assembly(string name, string password)
        {
            return new Person(name, password);
        }
    }
}
