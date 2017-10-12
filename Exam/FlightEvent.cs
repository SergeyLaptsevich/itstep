using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._07_exam
{   
    public class FlightEvent : EventArgs
    {
        public int Speed { get; set; }
        public int Height { get; set; }
        public bool IsFinished { get; set; }
        public bool GoToMenu { get; set; }

        public FlightEvent(int speed, int height, bool isFinished, bool goToMenu)
        {            
            Speed = speed;
            Height = height;
            IsFinished = isFinished;
            GoToMenu = goToMenu;
        }        
    }

    public class StartFlight
    {       
        public event EventHandler<FlightEvent> Flight;

        public void Start()
        {           
            Console.WriteLine("Speed — modified arrow keys Left and Right\n" +
                "(Right: +50 km/h, Left: –50 km/h, Shift-Right: +150 km/h, Shift - Left: –150 km/h)");
            Console.WriteLine("Height — changes the arrow keys Up and Down:\n" +
                "(Up: +250 m, Down: –250 m, Shift-Up: +500 m, Shift-Down: –500 m)");
            Console.WriteLine("Go to menu: M");

            FlightEvent events;
            do
            {
                var key = Console.ReadKey();
                Func<int, int> changeSpeed = null;
                Func<int, int> changeHeignt = null;
                Func<bool, bool> changeFinished = null;
                Func<bool, bool> changeGoToMenu = null;

                var speedMul = key.Modifiers.HasFlag(ConsoleModifiers.Shift) ? 3 : 1;
                var heightMul = key.Modifiers.HasFlag(ConsoleModifiers.Shift) ? 5 : 1;
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        changeSpeed = (x) => x - 50 * speedMul;
                        changeHeignt = (y) => y;
                        changeFinished = (z) => z;
                        changeGoToMenu = (m) => m;
                        break;
                    case ConsoleKey.RightArrow:
                        changeSpeed = (x) => x + 50 * speedMul;
                        changeHeignt = (y) => y;
                        changeFinished = (z) => z;
                        changeGoToMenu = (m) => m;
                        break;
                    case ConsoleKey.DownArrow:
                        changeSpeed = (x) => x;
                        changeHeignt = (y) => y - 50 * heightMul;
                        changeFinished = (z) => z;
                        changeGoToMenu = (m) => m;
                        break;
                    case ConsoleKey.UpArrow:
                        changeSpeed = (x) => x;
                        changeHeignt = (y) => y + 50 * heightMul;
                        changeFinished = (z) => z;
                        changeGoToMenu = (m) => m;
                        break;
                    case ConsoleKey.M:
                        changeSpeed = (x) => x;
                        changeHeignt = (y) => y;
                        changeFinished = (z) => z;
                        changeGoToMenu = (m) => true;
                        break;
                }          
                
                var resultSpeed = changeSpeed(0);
                var resultHeight = changeHeignt(0);
                var reusulFinished = changeFinished(false);
                var reusulGoToMenu = changeGoToMenu(false);

                events = new FlightEvent(resultSpeed, resultHeight, reusulFinished, reusulGoToMenu);
                OnStartFly(events);
            } while (!events.IsFinished);           
        }

        private void OnStartFly(FlightEvent events)
        {
            var handler = Flight;//handler указатель на функцию

            if (handler != null)
            {
                handler(this, events);
            }
        }
    }   
}
