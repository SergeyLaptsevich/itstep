using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Player[] players = new Player[] { new Player("Вася"), new Player("Петя"), new Player("Коля") };
            Game game = new Game(players);
            game.PlayerStep += Game_PlayerStep;
            game.RoundStart += Game_RoundStart;
            game.RoundEnd += Game_RoundEnd;
            game.PlayerOut += Game_PlayerOut;
            game.GameOver += Game_GameOver;
            game.Play();
        }     

        private static void Game_GameOver(object sender, PlayerEventArgs e)
        {
            Console.Clear();
            Console.WriteLine($"{e.Name} победил.");
        }

        private static void Game_PlayerOut(object sender, PlayerEventArgs e)
        {
            Console.WriteLine($"{e.Name} выбыл из игры.");
        }

        private static void Game_RoundEnd(object sender, PlayerEventArgs e)
        {
            Console.WriteLine($"{e.Name} забрал карты.");
        }

        private static void Game_RoundStart(object sender, EventArgs e)
        {
            Console.Clear();
        }

        private static void Game_PlayerStep(object sender, PlayerStepEventArgs e)
        {
            Console.WriteLine($"{e.Name} ({e.CardsCount} карт) выложил:\n{e.Card}");
        }
    }
}
