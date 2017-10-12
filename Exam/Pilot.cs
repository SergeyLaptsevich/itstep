using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._07_exam
{
    public class Pilot
    {
        public string Name { get; private set; }

        public Pilot(string name)
        {
            Name = name;
        }

        public string AddDispetcher()
        {
            Console.WriteLine("Enter dispatcher name: ");
            return Console.ReadLine();
        }
       
    }
}
