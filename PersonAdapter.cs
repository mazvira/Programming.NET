using System;

namespace Lab2
{
    internal static class PersonAdapter
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
