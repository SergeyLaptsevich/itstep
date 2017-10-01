using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class TeamLeader : IWorker
    {
        public string Name { get; set; }

        public TeamLeader(string name)
        {
            Name = name;
        }

        public bool Check(House house)
        {
            if(house.Basement.HasBuild)
            {
                Console.WriteLine("Basement has build");
            }
            if (house.Window1.HasBuild)
            {
                Console.WriteLine("Window and wall N1 has build");
            }
            if (house.Window2.HasBuild)
            {
                Console.WriteLine("Window and wall N2 has build");
            }
            if (house.Window3.HasBuild)
            {
                Console.WriteLine("Window and wall N3 has build");
            }
            if (house.Window4.HasBuild)
            {
                Console.WriteLine("Window and wall N4 has build");
            }
            if (house.Door.HasBuild)
            {
                Console.WriteLine("Door has build");
            }
            if (house.Roof.HasBuild)
            {
                Console.WriteLine("Roof has build");
            }
            return true;
        }
    }
}
