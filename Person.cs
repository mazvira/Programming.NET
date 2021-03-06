﻿using System;

namespace Lab2
{
    internal class Person
    {
        private readonly string _name;
        private readonly string _lastName;
        private readonly string _email;
        private DateTime _dateOfBirth;
        private readonly int _age;

        internal Person(string name, string lastName, string email, DateTime dateOfBirth)
        {
            _name = name;
            _lastName = lastName;
            _email = email;
            _dateOfBirth = dateOfBirth;
            _age = CountAge();
        }

        internal Person(string name, string lastName, string email) : this(name, lastName, email, DateTime.MinValue)
        {
            _name = name;
            _lastName = lastName;
            _email = email;
        }

        internal Person(string name, string lastName, DateTime dateOfBirth) : this(name, lastName, "user@example.con", DateTime.MinValue)
        {
            _name = name;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _age = CountAge();
        }

        internal string Name
        {
            get { return _name; }
        }

        internal string LastName
        {
            get { return _lastName; }
        }

        internal string Email
        {
            get { return _email; }
        }

        internal DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
        }

        internal int Age
        {
            get { return _age; }
        }
    
        internal bool IsAdult
        {  
            get { return _age >= 18; }
        }

        internal string SunSign
        {
            get { return SetSunHoroscope(); }
        }

        internal string ChineseSign
        {
            get { return SetChineseHoroscope(); }
        }

        internal bool IsBirthday
        {
          get { return _dateOfBirth.DayOfYear == DateTime.Today.DayOfYear;  }
        }

        private int CountAge()
        {
            int age = DateTime.Today.Year - _dateOfBirth.Year;

            if (_dateOfBirth.Month > DateTime.Today.Month || (_dateOfBirth.Month == DateTime.Today.Month && _dateOfBirth.Day > DateTime.Today.Day))
                age--;
            if (age > 135 || age < 0)
                throw new Exception();
            return age;
        }

        private string SetSunHoroscope()
        {
            switch (_dateOfBirth.Month)
            {
                case 1:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)
                        return "Capricorn";
                    else
                        return "Aquarius";
                case 2:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 19)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return " ";
        }

        private string SetChineseHoroscope()
        {
            int iChzod = _dateOfBirth.Year - ((_dateOfBirth.Year / 12) * 12);
            switch (iChzod)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
            }
            return " ";
        }
    }
 }
