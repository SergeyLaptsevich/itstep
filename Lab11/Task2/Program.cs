using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalyzer;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeAnalyzer.CodeAnalyzer analyzer = new CodeAnalyzer.CodeAnalyzer(@"..\..\..\InputCode.cs");
            analyzer.ToPrivate("out1.cs");
            analyzer.ToUpper("out2.cs");
            analyzer.Normalize("out3.cs");
            analyzer.Reverse("out4.cs");
        }
    }
}
