using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pocius_Mantas_IFF_9_5
{
    public class Student
    {
        public string ChosenModule { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        public Student(string takenModule, string surname, string name, string credits)
        {
            this.ChosenModule = takenModule;
            this.Surname = surname;
            this.Name = name;
            this.Group = credits;

        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            if (Name == other.Name)
            {
                return 0 - Surname.CompareTo(other.Surname);
            }
            return 0 - Name.CompareTo(other.Name);

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $@"{Surname} {Name} {ChosenModule}";
        }

        public bool Equals(Student other)
        {
            return (this.Surname == other.Surname && this.Name == other.Name && this.ChosenModule == other.ChosenModule);
        }

        public static bool operator >(Student a, Student b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator <(Student a, Student b)
        {
            return a.CompareTo(b) < 0;
        }
    }
}