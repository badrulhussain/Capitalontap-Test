using System;
using System.Collections.Generic;
using FlightBooking.Core;
using FlightBooking.Core.Service;
using static FlightBooking.Core.Enum.BookingEnum;

namespace FlightBooking.Console
{
    internal class Program
    {
        private static ScheduledFlight _scheduledFlight ;
        private static FlightRuleService _flightRuleService;
        private static AvailablePlaneService _availablePlaneService;

        private static void Main(string[] args)
        {
            SetupAirlineData();
            
            string command;
            do
            {
                System.Console.WriteLine("Please enter command.");
                command = System.Console.ReadLine() ?? "";
                var enteredText = command.ToLower();
                if (enteredText.Contains("print summary"))
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine(_scheduledFlight.GetSummary());
                }
                else if (enteredText.Contains("add general"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.General, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3])
                    });
                }
                else if (enteredText.Contains("add loyalty"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.LoyaltyMember, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                        LoyaltyPoints = Convert.ToInt32(passengerSegments[4]),
                        IsUsingLoyaltyPoints = Convert.ToBoolean(passengerSegments[5]),
                    });
                }
                else if (enteredText.Contains("add discounted"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.Discounted,
                        Name = passengerSegments[2],
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("add airline"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.AirlineEmployee, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("primary rule"))
                {
                    _flightRuleService._fluightRule = FlightRule.Primary;
                    System.Console.WriteLine(
                        string.Format("Flight rule set to: {0}", _flightRuleService._fluightRule));
                }
                else if (enteredText.Contains("secondary rule"))
                {
                    _flightRuleService._fluightRule = FlightRule.Secondary;
                    System.Console.WriteLine(
                        string.Format("Flight rule set to: {0}", _flightRuleService._fluightRule));
                }
                else if (enteredText.Contains("exit"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("UNKNOWN INPUT");
                    System.Console.ResetColor();
                }
            } while (command != "exit");
        }

        private static void SetupAirlineData()
        {
            _flightRuleService = new FlightRuleService();
            _availablePlaneService = new AvailablePlaneService();

            _availablePlaneService.Planes = new List<Plane>();
            _availablePlaneService.Planes.Add(new Plane { Id = 124, Name = "Bombardier Q400", NumberOfSeats = 15 });
            _availablePlaneService.Planes.Add(new Plane { Id = 125, Name = "ATR 640", NumberOfSeats = 20 });

            var londonToParis = new FlightRoute("London", "Paris")
            {
                BaseCost = 50, 
                BasePrice = 100, 
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            _scheduledFlight = new ScheduledFlight(
                londonToParis,
                _flightRuleService,
                _availablePlaneService);

            _scheduledFlight.SetAircraftForRoute(new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });

        }
    }
}
