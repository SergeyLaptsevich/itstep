using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class Basement : IPart
    {        
        public StringBuilder Part { get; set; }
        public bool HasBuild { get; set; }               

        public Basement()
        {
            Part = new StringBuilder();
            Part.Append("               \n");
            HasBuild = false;            
        }

        public void Build()
        {
            Part.Clear();
            Part.Append("|_|__________|_|");
            Console.WriteLine(Part);
        }
    }
}
