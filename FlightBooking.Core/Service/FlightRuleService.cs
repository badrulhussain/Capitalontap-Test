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
            if (_fluightRule == FlightRule.Primary)
            {
                if (profitSurplus > 0 &&
                    seatsTaken < Aircraft.NumberOfSeats &&
                    seatsTaken / (double)Aircraft.NumberOfSeats > FlightRoute.MinimumTakeOffPercentage)
                {
                    return true;
                }
            }
            if (_fluightRule == FlightRule.Secondary)
            {
                if (profitSurplus > costOfFlight &&
                    seatsTaken < Aircraft.NumberOfSeats &&
                    employeesAboard / (double)Aircraft.NumberOfSeats > FlightRoute.MinimumTakeOffPercentage)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
