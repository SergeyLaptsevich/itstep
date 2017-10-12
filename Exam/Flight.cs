using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._07_exam
{ 
    public class Flight
    {
        public Airplane airplane = new Airplane();        
        public Pilot Pilot { get; set; }
        public List<Dispatcher> allDispatcher = new List<Dispatcher>();
        public int CountActiveDispatchers { get; set; }        

        public Flight(string pilotName)
        {
            Pilot = new Pilot(pilotName);
            CountActiveDispatchers = 0;
        }

        public void AddDispatcher()
        {
            Console.WriteLine("You must have at least 2 dispatcher:");
            Console.WriteLine($"Now you have a {CountActiveDispatchers} dispatchers.");
            string name = Pilot.AddDispetcher();
            Dispatcher dispatcher = new Dispatcher(name);
            allDispatcher.Add(dispatcher);
            CountActiveDispatchers++;
        }

        public void DeleteDispatcher()
        {
            Console.WriteLine("Enter a number of dispatcher, which you want to change: ");
            int index = 0;
            
            foreach (var dispet in allDispatcher)
            {
                if (dispet.Active)
                {
                    Console.WriteLine($"{index} - {dispet.Name}");
                }
                index++;
            }
            int answerInt;
            do
            {                
                string answerStr = Console.ReadLine();
                answerInt = int.Parse(answerStr);

                if (answerInt == 3) { return; }

            } while (answerInt < 0 && answerInt >= allDispatcher.Count);

            allDispatcher[answerInt].Active = false;
            
            CountActiveDispatchers--;

            if (CountActiveDispatchers < 2)
            {
                AddDispatcher();
            }            
        }        

        public void StartFlight()
        {
            
            if(CountActiveDispatchers >= 2)
            {
                StartFlight fly = new StartFlight();              

                fly.Flight += (o, e) => { airplane.Speed += e.Speed;                    
                    Console.WriteLine($"Speed: {airplane.Speed}");                    
                };

                fly.Flight += (o, e) => {
                    airplane.Height += e.Height;                    
                    Console.WriteLine($"Height {airplane.Height}");
                };

                fly.Flight += (o, e) =>
                {             
                    foreach (var d in allDispatcher)
                    {
                        if (d.Active)
                        {
                            if(airplane.Speed >= 50 && d.FirstMove == 0)
                            {
                                d.ControlStart = true;
                            }                                              
                        }
                        if (d.ControlStart && d.Active)
                        {
                            if (airplane.Speed == 0 && airplane.Height == 0 && d.FirstMove >= 1)
                            {
                                Console.WriteLine("you have successfully landed the airplane");
                                GetAllPenaltyPoint();
                                e.IsFinished = true;
                            }
                            else
                            {
                                try
                                {
                                    d.CheckAirplane(airplane.Speed, airplane.Height);
                                }
                                catch (AirplaneIsCrashedException ex)
                                {
                                    Console.WriteLine("The airplane is crashed");
                                    GetAllPenaltyPoint();
                                    e.IsFinished = true;
                                }
                                catch (UnfitForFlightException ex)
                                {
                                    Console.WriteLine("You are unfit to flight.");
                                    GetAllPenaltyPoint();
                                    e.IsFinished = true;
                                }
                            }                            
                        }                        
                        else if (!d.ControlStart)
                        {
                            Console.WriteLine("For flight you need increase speed more the less 50 km/h.");
                            airplane.Height = 0;
                        }
                    }
                };

                fly.Flight += (o, e) =>
                {
                    if(e.GoToMenu == true)
                    {
                        if(Menu())
                        {
                            e.GoToMenu = false;
                        }                        
                    }                    
                };

                fly.Start();
            }
            else
            {
                Console.WriteLine("you can't begin to control the plane, as you have less than 2 dispatchers!");
            }
        }

        public bool Menu()
        {
            int answerInt = 0;
            do
            {
                Console.WriteLine("Menu:\nEnter what you want to do:");
                Console.WriteLine("1 - Add dispatcher\n2 - Delete dispatcher\n3 - StartFly\n4 - Exit");
                string answerStr = Console.ReadLine();
                answerInt = int.Parse(answerStr);                
                if (answerInt == 4) { return false; }
            } while (answerInt <= 0 && answerInt >= 4);
            
            switch(answerInt)
            {
                case 1:                    
                    AddDispatcher();
                    return true;
                case 2:
                    DeleteDispatcher();
                    return true;
                case 3:
                    StartFlight();
                    return true;
            }
            return false;
        }

        public void GetAllPenaltyPoint()
        {
            int allPenaltyPoint = 0;
            foreach(var dispatcher in allDispatcher)
            {
                allPenaltyPoint += dispatcher.PenaltyPoints;
            }
            Console.WriteLine($"Your penalty point {allPenaltyPoint}");
        }
    }
}
