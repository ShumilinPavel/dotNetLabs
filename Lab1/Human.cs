using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class Human
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
