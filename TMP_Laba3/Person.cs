using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP_Laba3
{
    public class Person
    {
        public string _name { get; private set; }
        public string _password { get; private set; }

        public Person(string name, string password)
        {
            _name = name; 
            _password = password;
        }
    }
}
