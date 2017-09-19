using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._18_HomeWork
{
    public struct Request
    {
        private string codeOrder;
        private Client orderClient;
        private Article[] orderArticle;
        private string orderData;
        private decimal orderSum;
        public PayType PayType { get; set; }

        public string CodeOrder
        {
            get { return codeOrder; }
            set
            {
                int number = 1000;
                number += 1;

                StringBuilder str = new StringBuilder();
                str.Append(number.ToString() + "BYNOrder");

                codeOrder = str.ToString();
            }
        }

        public Client RequestClient
        {
            get { return orderClient; }
            set
            {
                orderClient = value;
            }
        }

        public Article[] OrderArtide
        {
            get { return orderArticle; }
            set
            {
                orderArticle = new Article[30];
                orderArticle = value;
            }
        }

        public string OrderData
        {
            get { return orderData; }
            set
            {
                DateTime dateNow = DateTime.Now;
                orderData = dateNow.ToString();                
            }
        }

        public decimal OrderSum
        {
            get
            {
                orderSum = 0;
                foreach (var i in orderArticle)
                {
                    orderSum += (decimal)i.PriceProduct;
                }
                return orderSum;
            }
            set { orderSum += value; }
        }
    }
}
