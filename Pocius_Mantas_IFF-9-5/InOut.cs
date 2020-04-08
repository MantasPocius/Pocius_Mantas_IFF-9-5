using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pocius_Mantas_IFF_9_5
{
    public class InOut
    {
        public static List<Student> ReadStudentData(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            List<Student> students = new List<Student>();
            foreach(var line in lines)
            {
                string[] values = line.Split(' ');
                string module = values[0];
                string surName = values[1];
                string name = values[2];
                string group = values[3];
                Student student = new Student(module, surName, name, group);
                students.Add(student);
            }
            return students;
        }

        public static MyList ReadModuleData(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            MyList modules = new MyList();
            foreach(var line in lines)
            {
                string[] values = line.Split(' ');
                string moduleName = values[0];
                string surName = values[1];
                string name = values[2];
                int credits = int.Parse(values[3]);
                Module module = new Module(moduleName, surName, name, credits);
                modules.Add(module);
            }
            return modules;
        }
    }
}