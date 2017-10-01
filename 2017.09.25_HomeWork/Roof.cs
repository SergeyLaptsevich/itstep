using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public class Roof : IPart
    {        
        public StringBuilder Part { get; set; }
        public bool HasBuild { get; set; }

        public Roof()
        {
            Part = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                Part.Append("               \n");
            }
           
            HasBuild = false;
        }

        public void Build()
        {
            Part.Clear();
            Part.Append("       /\\\n");
            Part.Append("      /  \\\n");
            Part.Append("     /    \\\n");
            Part.Append("    /      \\\n");
            Part.Append("   /        \\\n");
            Part.Append("  /          \\\n");
            Part.Append(" /            \\\n");
            Part.Append("/              \\");

            HasBuild = true;

            Console.WriteLine(Part);
        }
    }
}
