using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Game
    {
        public event EventHandler<PlayerEventArgs> GameOver;//конец игры
        public event EventHandler<PlayerStepEventArgs> PlayerStep;//когда игрок кладет карту на стол
        public event EventHandler<PlayerEventArgs> PlayerOut;//игрок выбывает
        public event EventHandler<PlayerEventArgs> RoundEnd;//игрок выигрывает карты со строла
        public event EventHandler<EventArgs> RoundStart;//начало нового раунда

        public List<Player> Players { get; private set; }

        public Game(IEnumerable<Player> players)
        {
            if(players.Count() < 2 || players.Count() > 6)
                throw new Exception("Количество игроков должно быть от 2 до 6.");

            Players = new List<Player>(players);
        }

        public void Play()
        {
            CardDeck deck = new CardDeck();
            GiveOutCards(deck, Players);
            List<Card> table = new List<Card>();

            while(Players.Count != 1)
            {
                OnRoundStart();
                //выложили карты на стол
                foreach(var player in Players)
                {
                    table.Add(player.PutCard());
                    OnPlayerStep(player, table.Last());
                    Thread.Sleep(300);
                }

                //определили победившего, забрали карты со стола
                int max_card_index = table.IndexOf(table.Max());
                Players[max_card_index].GetCards(table);
                OnRoundEnd(Players[max_card_index]);
                table.Clear();
                Thread.Sleep(1000);

                //удаление проигравших
                for (int i = 0; i < Players.Count; i++)
                    if(Players[i].CardsCount == 0)
                    {
                        OnPlayerOut(Players[i]);
                        Players.RemoveAt(i);
                        i--;
                        Thread.Sleep(2000);
                    }
            }

            OnGameOver(Players[0]);
        }

        private void GiveOutCards(CardDeck deck, IEnumerable<Player> players)
        {
            while (deck.Size != 0)
                foreach (var player in players)
                    if (deck.Size == 0)
                        break;
                    else
                        player.GetCard(deck.GetCard());
        }

        private void OnGameOver(Player player)
        {
            GameOver?.Invoke(this, new PlayerEventArgs(player.Name));
        }

        private void OnPlayerOut(Player player)
        {
            PlayerOut?.Invoke(this, new PlayerEventArgs(player.Name));
        }

        private void OnRoundStart()
        {
            RoundStart?.Invoke(this, new EventArgs());
        }

        private void OnRoundEnd(Player player)
        {
            RoundEnd?.Invoke(this, new PlayerEventArgs(player.Name));
        }

        private void OnPlayerStep(Player player, Card card)
        {
            PlayerStep?.Invoke(this, new PlayerStepEventArgs(player.ToString(), player.CardsCount, card.ToString()));
        }
    }
}
