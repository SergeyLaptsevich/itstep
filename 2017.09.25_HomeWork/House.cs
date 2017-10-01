using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class House
    {
        public IPart Basement { get; set; }
        public IPart Wall1 { get; set; }
        public IPart Wall2 { get; set; }
        public IPart Wall3 { get; set; }
        public IPart Wall4 { get; set; }
        public IPart Window1 { get; set; }
        public IPart Window2 { get; set; }
        public IPart Window3 { get; set; }
        public IPart Window4 { get; set; }
        public IPart Door { get; set; }
        public IPart Roof { get; set; }

        public House()
        {
            Basement = new Basement();
            Wall1 = new Wall();
            Wall2 = new Wall();
            Wall3 = new Wall();
            Wall4 = new Wall();
            Window1 = new Window();
            Window2 = new Window();
            Window3 = new Window();
            Window4 = new Window();
            Door = new Door();
            Roof = new Roof();
        }

        


       


    }
}
