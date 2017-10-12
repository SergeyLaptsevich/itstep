using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._07_exam
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Hello, pilot! Enter your name please: ");
            string pilotName = Console.ReadLine();
            Flight flight = new Flight(pilotName);

            Console.WriteLine("{0}, you control the airplane Tu-154.", pilotName);

            while(flight.Menu())
            {                
            }           
        }
    }
}
