using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3];

            Console.WriteLine("Enter names");

            for (int i = 0; i < 3; i++) {
                if (i == 0)
                {
                    persons[i] = new Teacher(Console.ReadLine());
                }
                else { 
                    persons[i] = new Student(Console.ReadLine());
                }
            }

            for (int i = 0; i < 3; i++) {
                if (persons[i] is Teacher)
                {
                    ((Teacher)persons[i]).explain();
                }
                else {
                    ((Student)persons[i]).study();
                }
            }

           // ((Teacher)persons[1]).explain();
           //(Student)persons[2]).study();

            Console.ReadKey();
        }
    }

    class Student : Person
    {
        public Student(string name) : base(name)
        {
            this.name = name;
        }

        public override void toString()
        {
            Console.WriteLine(this.name + " is studying!");
        }

        public void study() {
            // Console.WriteLine(this.name + " is studying!");
            this.toString();
        }
    }

    class Teacher : Person {

        public Teacher(string name) : base(name) {
            this.name = name;
        }

        public override void toString()
        {
            Console.WriteLine(this.name + " is explaining");
        }

        public void explain()
        { 
           // Console.WriteLine(this.name + " is explaining");
           this.toString();
        }
    }

    class Person {
        protected string name;

        public Person(string name) { 
            this.name = name;
        }

        public virtual void toString() {
            Console.WriteLine("Name - " + name);
        }
    }

}
