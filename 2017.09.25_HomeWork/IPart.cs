using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._25_HomeWork
{
    public interface IPart
    {        
        StringBuilder Part { get; set; }
        bool HasBuild { get; set; }

        void Build();
    }
}
