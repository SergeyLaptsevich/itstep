using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._07_exam
{
    public class Dispatcher
    {
        public string Name { get; private set; }
        public bool Active { get; set; }
        public string Id { get; private set; }
        public CityEnum city { get; set; }    
        public int AdjustmenWeatherConditions { get; set; }
        public int FirstMove { get; set; }
        public int RecommendedHeightFlight { get; set; }
        public int PenaltyPoints { get; set; }
        public bool ControlStart { get; set; }

        public Dispatcher(string name)
        {
            Random rand = new Random();
            Name = name;
            Id = GenerateID();
            Active = true;
            AdjustmenWeatherConditions = rand.Next(-200, 200);
            city = (CityEnum)rand.Next(1, 9);
            FirstMove = 0;
            PenaltyPoints = 0;
            ControlStart = false;
        }

        private string GenerateID()
        {
            DateTime date = DateTime.Now;            
            return date.Second.ToString() + Name;
        }  
        
        public void CheckAirplane(int speed, int height)
        {            
            ++FirstMove;
            RecommendedHeightFlight = 7 * speed - AdjustmenWeatherConditions; 
            Console.WriteLine($"Dispatcher {Name} recommended height of flight: {RecommendedHeightFlight}");           

            int difference = 0;

            difference = Math.Abs(height - RecommendedHeightFlight);

            if (difference >= 300 && difference < 600)
            {
                PenaltyPoints += 25;
            }
            else if (difference >= 600 && difference < 1000)
            {
                PenaltyPoints += 50;
            }
            else if (difference >= 1000 || ((speed == 0 && height == 0) && FirstMove < 2))
            {                
                throw new AirplaneIsCrashedException();
            }
            else if (speed < 50)
            {                
                throw new AirplaneIsCrashedException();
            }
            else if(speed > 1000)
            {
                PenaltyPoints += 100;
                Console.WriteLine("Please, reduce speed.");
            }
            
            if (PenaltyPoints > 1000)
            {                
                throw new UnfitForFlightException();
            }
        }
    }
}
