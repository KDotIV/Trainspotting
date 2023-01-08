using System;
using Trainspotting.Services;

namespace Trainspotting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Initialize initialize = new Initialize();

            var data = initialize.FetchData();

            Booking newBooking = new Booking();

            newBooking.DisplayTrains(data);

            var bookedSeat = newBooking.StartBooking(data);

            if (bookedSeat.Item2 == true)
            {
                Console.WriteLine("Seat Booked...");
                var newData = initialize.UpdateSeats(bookedSeat.Item1);
            }
        }
    }
}
