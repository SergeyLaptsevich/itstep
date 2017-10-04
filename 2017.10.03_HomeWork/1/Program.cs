using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2017._10._03_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Information info = new Information(5, 3);
            
            
            FileStream streamCreate;
            if (!File.Exists("Day17.txt"))
            {
                using (streamCreate = File.Create("Day17.txt", 10000))
                {                    
                }
            }
            else
            {
                Console.WriteLine("The file already exist");
            }
            
            try
            {
                using (var stream = new FileStream("Day17.txt", FileMode.Open, FileAccess.ReadWrite))
                {
                    var writer = new BinaryWriter(stream);
                    writer.Write("Tsarova");
                    writer.Write("Alisa");
                    writer.Write(info.SizeX);
                    writer.Write(info.SizeY);

                    for (int i = 0; i < info.SizeX; i++)
                    {
                        for (int j = 0; j < info.SizeY; j++)
                        {
                            writer.Write(info.arrayDouble[i, j]);
                        }
                        writer.Write("\n");
                    }

                    writer.Write(1989);
                    writer.Write(3);
                    writer.Write(5);
                    writer.Flush();
                    writer.Seek(0, SeekOrigin.Begin);

                    using (var reader = new BinaryReader(stream))
                    {                        
                        info.FirstName = reader.ReadString();
                        info.SecondName = reader.ReadString();
                        info.SizeX = reader.ReadInt32();
                        info.SizeY = reader.ReadInt32();
                        for (int i = 0; i < info.SizeX; i++)
                        {
                            for (int j = 0; j < info.SizeY; j++)
                            {
                                info.arrayDouble[i, j] = reader.ReadDouble();
                            }
                            reader.ReadString();
                        }
                        DateTime t = new DateTime(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
                        info.DateBirth = t;                  
                    }
                }
                
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
