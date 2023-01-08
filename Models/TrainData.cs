using System.Collections.Generic;

namespace Trainspotting.Models
{
    public class TrainData
    {
        public string DepatureTime { get; set; }
        public string Destination { get; set; }
        public List<Seat> Seats { get; set; }

        public TrainData(string depatureTime, string destination, List<Seat> seats)
        {
            DepatureTime = depatureTime;
            Destination = destination;
            Seats = seats;
        }
    }
}
