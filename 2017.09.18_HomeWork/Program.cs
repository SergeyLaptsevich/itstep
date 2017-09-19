using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._18_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Article product = new Article();

            product.CodeProduct = "Apple";            
            product.NameProduct = "Apple";
            product.PriceProduct = 104;

            Console.WriteLine(product);

            Client client = new Client();

            client.CodeClient = string.Empty;
            
            Console.WriteLine(client.CodeClient);
                        
            string name = Console.ReadLine();
            string[] arrName = new string[3];
            arrName = name.Split(new[] { ' ' });
            client.NameClient = arrName;

            client.Address = "Smirnova st, 14";
            client.PhoneNumber = Console.ReadLine();            

            Console.WriteLine(client);            

            string str = Console.ReadLine();

            int intValue;

            if (int.TryParse(str, out intValue))
            {
                product.typeProduct = (ArticleType)intValue;
            }
            else
            {
                product.typeProduct = (ArticleType)Enum.Parse(typeof(ArticleType), str);
            }

            str = Console.ReadLine();

            if (int.TryParse(str, out intValue))
            {
                client.TypeClient = (ClientType)intValue;
            }
            else
            {
                client.TypeClient = (ClientType)Enum.Parse(typeof(ClientType), str);
            }

        }
    }
}
