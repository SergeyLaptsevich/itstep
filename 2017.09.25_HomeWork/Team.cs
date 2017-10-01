using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class Team
    {
        public IWorker Worker1 { get; set; }
        public IWorker Worker2 { get; set; }
        public IWorker Worker3 { get; set; }
        public IWorker TeamLeader { get; set; }
        public House house = new House();     
                
        public Team()
        {
            Worker1 = new Worker("Vasya");
            Worker2 = new Worker("Dima");
            Worker3 = new Worker("Oleg");

            TeamLeader = new TeamLeader("Boss");
        }
               

        public void BuildHouse()
        {
            house.Roof.Build();
            house.Window1.Build();
            house.Wall1.HasBuild = true;
            house.Window2.Build();
            house.Wall2.HasBuild = true;
            house.Window3.Build();
            house.Wall3.HasBuild = true;
            house.Window4.Build();
            house.Wall4.HasBuild = true;
            house.Door.Build();
            house.Basement.Build();
        }

        public void CheckBuild(House house, IWorker worker)
        {
            worker.Check(house);
        }
    }
}
