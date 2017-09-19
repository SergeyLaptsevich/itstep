using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._18_HomeWork
{
    public struct Article
    {
        private string codeProduct;
        private int priceProduct;
        public ArticleType typeProduct { get; set; }

        public string NameProduct { get; set; }

        public string CodeProduct
        {
            get { return codeProduct; }
            set
            {
                int number = 0;
                number += 1;

                codeProduct = number.ToString() + value;
            }
        }        

        public int PriceProduct
        {
            get { return priceProduct; }
            set
            {
                priceProduct = Math.Min(100, Math.Max(0, value));
            }
        }

        

        public override string ToString()
        {
            return string.Format("Artide:\nName: {0}\nCode: {1}\nPrice: {2}\nType: {3}", NameProduct, CodeProduct, PriceProduct, typeProduct);
        }
    }
}
