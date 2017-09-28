/*1. В С # индексация начинается с нуля, но в некоторых языках программирования это не так.
Например, в Turbo Pascal индексация массиве начинается с 1.
Напишите класс RangeOfArray, который позволяет работать с массивом такого типа,
в котором индексный диапазон устанавливается пользователем. 
Например, в диапазоне от 6 до 10, или от –9 до 15.
Подсказка: В классе можно объявить две переменных, 
которые будут содержать верхний и нижний индекс допустимого диапазона.*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._19_HomeWork_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            RangeOfArray array = new RangeOfArray(-14, 5);
            
            array[-1] = 5;

            Console.WriteLine(array[-5]);            
        }
    }
}
