using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._19_HomeWork_task1
{
    public class RangeOfArray
    {
        private int beginIndex;
        private int endIndex;        
        private int[] array;

        
        public RangeOfArray(int begin, int end)
        {
            beginIndex = begin;
            endIndex = end > beginIndex ? end : beginIndex + 1;

            array = new int[endIndex - begin];
        }                 

        public int this[int i]
        {
            get
            {
                int index;
                if (i >= beginIndex && endIndex - beginIndex <= array.Length)
                {
                    index = Math.Abs(beginIndex) - Math.Abs(i);
                    return array[index];
                }

                throw new ArgumentOutOfRangeException();
            }            
            set
            {
                int index;
                if (i >= beginIndex && endIndex - beginIndex <= array.Length)
                {
                    index = Math.Abs(beginIndex) - Math.Abs(i);
                    array[index] = value;
                }

                //throw new ArgumentOutOfRangeException();
            }
        }

        
    }
}
