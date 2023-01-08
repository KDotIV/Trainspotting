using System;
using System.Collections.Generic;
using Trainspotting.Models;

namespace Trainspotting.Services
{
    public class Booking
    {
        public void DisplayTrains(List<TrainData> trainData)
        {
            Console.WriteLine("Current Depatures:");

            foreach (var train in trainData)
            {
                Console.WriteLine($"[{trainData.IndexOf(train) + 1}] Destination: {train.Destination} - Departing: {train.DepatureTime} - Available Seats: {train.Seats.Count}");
            }
        }

        public Tuple<Seat, bool> StartBooking(List<TrainData> trainData)
        {
            Console.WriteLine("Select a Destination By Number....");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > trainData.Count || input < 0)
            {
                Console.WriteLine("Incorrect Selection.....");
                StartBooking(trainData);
            }

            var selectedTrain = trainData[input - 1];

            Console.WriteLine($"{selectedTrain.Destination} was Selected");

            List<Seat> tempAisle = new List<Seat>();
            List<Seat> tempWindow = new List<Seat>();

            foreach (var seat in selectedTrain.Seats)
            {
                if (seat.Occupied == false)
                {
                    if (seat.SeatType == SeatType.Aisle)
                    {
                        tempAisle.Add(seat);
                    }
                    else
                    {
                        tempWindow.Add(seat);
                    }
                }
            }

            if (tempAisle.Count == 0 && tempWindow.Count == 0) { Console.WriteLine("There are no seats available. Would you like to choose a different destination?"); }

            if (tempAisle.Count == 0)
            {
                Console.WriteLine($"There are only window seats available \n " +
                    "Would you like to book a window seat? y or n ");

                string windowInput = Console.ReadLine();

                if (windowInput == "y")
                {
                    tempWindow[0].Occupied = true;
                    Console.WriteLine("Window Seat has been booked.");

                    Tuple<Seat, bool> result = new Tuple<Seat, bool>(tempWindow[0], true); return result;

                }
                else if (windowInput == "n")
                {
                    Console.WriteLine("Exiting Booking...");

                    Tuple<Seat, bool> result = new Tuple<Seat, bool>(null, false); return result;
                }
            }
            else if (tempWindow.Count == 0)
            {
                Console.WriteLine($"There are only aisle seats available \n" +
                    "Would you like to book an aisle seat? y or n");

                string aisleInput = Console.ReadLine();

                if (aisleInput == "y")
                {
                    tempAisle[0].Occupied = true;
                    Console.WriteLine("Aisle Seat has been booked.");

                    Tuple<Seat, bool> result = new Tuple<Seat, bool>(tempAisle[0], true); return result;

                }
                else if (aisleInput == "n")
                {
                    Console.WriteLine("Exiting Booking...");

                    Tuple<Seat, bool> result = new Tuple<Seat, bool>(null, false); return result;
                }
            }
            else
            {
                Console.WriteLine($"There are {tempAisle.Count} & {tempWindow.Count} seats available \n" +
                $"Choose '1' for Aisle seat or '2' for Window seat");

                int seatInput = Convert.ToInt32(Console.ReadLine());

                switch (seatInput)
                {
                    case 1:
                        tempAisle[0].Occupied = true;
                        Tuple<Seat, bool> aisleResult = new Tuple<Seat, bool>(tempAisle[0], true); return aisleResult;
                    case 2:
                        tempWindow[0].Occupied = true;
                        Tuple<Seat, bool> windowResult = new Tuple<Seat, bool>(tempWindow[0], true); return windowResult;
                }
            }
            return null;
        }
    }
}
