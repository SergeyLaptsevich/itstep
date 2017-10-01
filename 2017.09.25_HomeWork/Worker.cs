using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class Worker : IWorker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            Name = name;
        }

        public bool Check(House house)
        {
            int answer = 0;
            Console.WriteLine("What part you want check?\n1 - basement, 2 - wall1, 3 - wall2, 4 - wall3, 5 - wall4\n" +
                "6 - window1, 7 - window2, 8 - window3, 9 - window4, 10 - door, 11 - roof");
            answer = Console.Read();
            switch (answer)
            {
                case 1:
                    return house.Basement.HasBuild;
                case 2:
                    return house.Wall1.HasBuild;
                case 3:
                    return house.Wall2.HasBuild;
                case 4:
                    return house.Wall3.HasBuild;
                case 5:
                    return house.Wall4.HasBuild;
                case 6:
                    return house.Window1.HasBuild;
                case 7:
                    return house.Window2.HasBuild;
                case 8:
                    return house.Window3.HasBuild;
                case 9:
                    return house.Window4.HasBuild;
                case 10:
                    return house.Door.HasBuild;
                case 11:
                    return house.Roof.HasBuild;
                default:
                    return false;
                
            }
        }
    }
}
