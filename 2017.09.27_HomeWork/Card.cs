using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._27_HomeWork
{
    public class Card
    {        
        public string Key { get; set; }
        public int Value { get; set; }

        public Card(string key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}
