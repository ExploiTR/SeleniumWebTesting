using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    internal class Program2
    {

    }

    class UseStudent
    {
        public static void Main()
        {
            Student student = new Student("C#", "Pratim", 1);
            Student student1 = new Student("ASP.NET", "Pratim", 2);

            student.Payment(1500);
            student1.Payment(2000);

            student.Print();
            student1.Print();

            Console.ReadKey();
        }
    }

    class Student
    {
        private string course;
        private double feesPaid;
        private string name;
        private int rollno;

        private double dueAmount;
        private static double service_Tax = 12.5d;
        private double totalFee;

        public Student(string course, string name, int roll)
        {
            this.course = course;
            this.name = name;
            this.rollno = roll;

            dueAmount = course.Equals("C#") ? 2000 : 3000;
        }

        public double DueAmount
        {
            get
            {
                return dueAmount;
            }
            set
            {
                dueAmount = value;
            }
        }

        public double ServiceTax
        {
            get
            {
                return service_Tax;
            }
            set
            {
                service_Tax = value;
            }
        }

        public double TotalFee
        {
            get
            {
                return totalFee;
            }
            set
            {
                totalFee = value;
            }
        }

        public void Payment(double amount)
        {
            totalFee = dueAmount + (dueAmount * (service_Tax/100));
            feesPaid = amount;
            totalFee = totalFee - amount;
        }

        public void Print()
        {
            Console.WriteLine("name - " + name);
            Console.WriteLine("roll - " + rollno);
            Console.WriteLine("feespaid - " + feesPaid);
            Console.WriteLine("service tax - " + service_Tax);
            Console.WriteLine("total fee remaining - " + totalFee);
            Console.WriteLine();
        }
    }
}
