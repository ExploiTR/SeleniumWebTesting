using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Vehicle();
            v.Model = "Generic";
            v.drive();

            Car c = new Car();
            c.Model = "Sedan";
            c.drive();

            Sportscar s = new Sportscar();
            s.Model = "Sport CAR";
            s.drive();

            Van van = new Van();
            van.Model = "Van";
            v.drive();

            ExcursionVan ex = new ExcursionVan();
            ex.Model = "Excursion Van";
            ex.drive();

            Minivan minivan = new Minivan();
            minivan.Model = "Minivan";
            minivan.setCargoNet(true);
            minivan.setDualSlidingDoors(true);
            minivan.drive();

            Console.ReadKey();
        }
    }

    class Vehicle {
        private string make;
        private string model;
        private int year;

        public Vehicle() { 
        
        }

        public string Make
        {
            get { return make; }
            set { make = value; }   
        }

        public string Model { 
            set { model = value; }
            get { return model; }
        
        }

        public int Year {
            set { year = value; }
            get { return year; }
        }

        public void accelerate(){
            Console.WriteLine("Accelerating...");        
        }

        public void decelerate() { 
        
        }

        public void drive() {
            Console.WriteLine(this.model + " is driving..");
        }

        public void start() { 
        
        }

        public void stop() {
        
        }


    }

    class Car : Vehicle { 
    
    }

    class Sportscar : Car{ 
    
    }

    class Van : Vehicle { 
    
    }

    class ExcursionVan : Van { 
    
    }

    class Minivan : Van {
        private bool cargo_net;
        private bool dual_Sliding;

        public Minivan() { 
        
        }

        public Minivan(bool cargo_net, bool dual_Sliding)
        {
            this.cargo_net = cargo_net; 
            this.dual_Sliding = dual_Sliding;
        }


        public bool hasCargoNet() { 
            return cargo_net;
        }

        public bool hasDualSliding() {
            return dual_Sliding;
        }

        public void setCargoNet(bool status) { 
            cargo_net = status;
        }

        public void setDualSlidingDoors(bool status) {
            dual_Sliding = status;  
        }
    }









































}
