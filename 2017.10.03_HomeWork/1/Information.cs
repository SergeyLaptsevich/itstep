using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._03_HomeWork
{
    public struct Information
    {   
        public string SecondName { get; set; }
        public string FirstName { get; set; }

        public double[,] arrayDouble;
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public DateTime DateBirth { get; set; }
        public int[,] arrayInt;

        public Information(int x, int y)
        {
            SizeX = x;
            SizeY = y;

            arrayDouble = new double[SizeX, SizeY];
            arrayInt = new int[SizeX, SizeY];

            float value = 0.1F;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    value = value + 0.1F;
                    arrayDouble[i, j] = value;
                    arrayInt[i, j] = j;
                }
            }            

            FirstName = string.Empty;
            SecondName = string.Empty;
            DateBirth = new DateTime();

        }

    }
}
