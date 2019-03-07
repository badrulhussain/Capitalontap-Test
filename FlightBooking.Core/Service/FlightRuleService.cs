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
            int seatsTaken,
            Plane Aircraft,
            FlightRoute FlightRoute)
        {
            if (_fluightRule == FlightRule.Primary)
            {
                if (profitSurplus > 0 &&
                    seatsTaken < Aircraft.NumberOfSeats &&
                    seatsTaken / (double)Aircraft.NumberOfSeats > FlightRoute.MinimumTakeOffPercentage)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
