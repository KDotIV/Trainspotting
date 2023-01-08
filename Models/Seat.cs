namespace Trainspotting.Models
{
    public class Seat
    {
        public bool Occupied { get; set; }
        public SeatType SeatType { get; set; }
    }

    public enum SeatType
    {
        Window = 0,
        Aisle = 1
    }
}
