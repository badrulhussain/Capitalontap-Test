using System;
using System.Collections.Generic;
using System.Text;

namespace FlightBooking.Core.Service
{
    public class AvailablePlaneService
    {
        public List<Plane> Planes;

        public List<Plane> GetWithMoreSeats(int seatsTaken)
        {
            var AvailablePlanes = new List<Plane>();
            foreach (var  plane in Planes)
            {
                if (plane.NumberOfSeats > seatsTaken)
                    AvailablePlanes.Add(plane);
            }
            return AvailablePlanes;
        }
    }
}
