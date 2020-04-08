using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pocius_Mantas_IFF_9_5
{
    public class Module
    {
        public string ModuleName { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public Module(string moduleName, string surname, string name, int credits)
        {
            this.ModuleName = moduleName;
            this.Surname = surname;
            this.Name = name;
            this.Credits = credits;

        }

        public int CompareTo(Module other)
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
            return $@"{Surname} {Name} {ModuleName}";
        }

        public bool Equals(Module other)
        {
            return (this.Surname == other.Surname && this.Name == other.Name && this.ModuleName == other.ModuleName);
        }

        public static bool operator >(Module a, Module b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator <(Module a, Module b)
        {
            return a.CompareTo(b) < 0;
        }
    }
}