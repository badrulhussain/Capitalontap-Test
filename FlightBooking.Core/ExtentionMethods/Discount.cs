using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBooking.Core.ExtentionMethods
{
    public static class Discount
    {
        public static double applyDiscount(this double price, int deductionValue)
        {
            return price - ((deductionValue / 100) * price);
        }
    }
}