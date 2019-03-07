using System;
using System.Collections.Generic;
using System.Text;
using static FlightBooking.Core.Enum.BookingEnum;

namespace FlightBooking.Core.Service
{
    public class FlightRuleService
    {
        public FlightRule _fluightRule { get; set; } =
            FlightRule.Primary;

        public bool Get(double profitSurplus,
            double costOfFlight,
            int seatsTaken,
            int employeesAboard,
            Plane Aircraft,
            FlightRoute FlightRoute)
        {
            if (seatsTaken < Aircraft.NumberOfSeats)
            {
                switch (_fluightRule)
                {
                    case FlightRule.Primary:
                        {
                            if (profitSurplus > 0 &&
                                seatsTaken / (double)Aircraft.NumberOfSeats > FlightRoute.MinimumTakeOffPercentage)
                                return true;
                            break;
                        }
                    case FlightRule.Secondary:
                        {
                            if (profitSurplus > costOfFlight &&
                                employeesAboard / (double)Aircraft.NumberOfSeats > FlightRoute.MinimumTakeOffPercentage)
                                return true;
                        }
                        break;
                    default:
                        {
                            return false;
                        }
                }
            }

            return false;
        }
    }
}
