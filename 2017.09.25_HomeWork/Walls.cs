using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class Wall : IPart
    {        
        public StringBuilder Part { get; set; }
        public bool HasBuild { get; set; }        

        public Wall()
        {
            Part = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                Part.Append("               \n");
            }
            HasBuild = false;            
        }

        public void Build()
        {
            Part.Clear();
            for (int i = 0; i < 6; i++)
            {                
                Part.Append("| |          | |\n");                
            }
            HasBuild = true;

            Console.WriteLine(Part);
        }
    }
}
