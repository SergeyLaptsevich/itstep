using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._18_HomeWork
{
    public struct Client
    {
        private string codeClient;
        private string[] nameClient;
        private int countOrders;
        public ClientType TypeClient { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }        
               
        public string CodeClient
        {
            get { return codeClient; }
            set
            {
                int number = 2000;
                number += 1;

                codeClient = number.ToString() + "CLIENT";
            }
        }

        public string[] NameClient
        {
            get { return nameClient; }
            set
            {
                nameClient = new string[3];
                nameClient = value;
            }
        }

        public int CountOrders
        {
            get { return countOrders; }
            set
            {
                countOrders += value;
            }
        }


        public override string ToString()
        {
            return string.Format("\nClient:\nFirstName: {0}\nSecontName: {1}\nTriedName: {2}\nCode: {3}\nAddress: {4}\n" +
                "Phone number: {5}", 
                nameClient[0], nameClient[1], nameClient[2], CodeClient, Address, PhoneNumber);
        }
    }
}
