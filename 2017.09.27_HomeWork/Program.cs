using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._27_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.HowPlayers();
            game.DistributeCards();

            game.ShowCardPlayer();

            game.Play();

            game.PrintWinner();
            
        }
    }
}
