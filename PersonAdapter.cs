using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    static class PersonAdapter
    {
        internal static Person CreatePerson(string name, string lastName, string email, DateTime dateOfBirth)
        {
            try
            {
                return new Person(name, lastName, email, dateOfBirth);
            }
            catch
            {
                return null;
            }

        }
    }
}
