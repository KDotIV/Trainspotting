using System;
using System.Collections.Generic;
using System.Linq;
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

        public Tuple<TrainData, bool> StartBooking(List<TrainData> trainData)
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

            if(SelectSeat(selectedTrain))
            {
                Tuple<TrainData, bool> result = new Tuple<TrainData, bool>(selectedTrain, true);
                return result;
            }
            else
            {
                StartBooking(trainData);
            }

            return null;
        }

        private bool SelectSeat(TrainData selectedTrain)
        {
            var openAisle = selectedTrain.Seats.FirstOrDefault(x => x.SeatType == SeatType.Aisle && x.Occupied == false);
            var openWindow = selectedTrain.Seats.FirstOrDefault(x => x.SeatType == SeatType.Window && x.Occupied == false);

            if (openAisle == null && openWindow == null) 
            { 
                Console.WriteLine("There are no seats available. Choose a different destination...");
                return false; 
            }

            if (openAisle == null)
            {
                Console.WriteLine($"There are only window seats available \n " +
                    "Would you like to book a window seat? y or n ");

                string windowInput = Console.ReadLine();

                if (windowInput == "y")
                {

                    Tuple<TrainData, bool> result = new Tuple<TrainData, bool>(selectedTrain, true);

                    Console.WriteLine("Window Seat has been booked.");
                    selectedTrain.Seats[openWindow.seatNum].Occupied = true;

                    return true;

                }
                else if (windowInput == "n")
                {
                    Console.WriteLine("Exiting Booking...");
                    return false;
                }
            }
            else if (openWindow == null)
            {
                Console.WriteLine($"There are only aisle seats available \n" +
                    "Would you like to book an aisle seat? y or n");

                string aisleInput = Console.ReadLine();

                if (aisleInput == "y")
                {
                    selectedTrain.Seats[openAisle.seatNum].Occupied = true;
                    Console.WriteLine("Aisle Seat has been booked.");
                    return true;

                }
                else if (aisleInput == "n")
                {
                    Console.WriteLine("Exiting Booking..."); 
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"There are Aisle & Window seats available \n" +
                    $"Choose '1' for Aisle seat or '2' for Window seat");

                int seatInput = Convert.ToInt32(Console.ReadLine());

                switch (seatInput)
                {
                    case 1:
                        selectedTrain.Seats[openAisle.seatNum].Occupied = true;
                        Tuple<TrainData, bool> aisleResult = new Tuple<TrainData, bool>(selectedTrain, true); return true;
                    case 2:
                        selectedTrain.Seats[openWindow.seatNum].Occupied = true;
                        Tuple<TrainData, bool> windowResult = new Tuple<TrainData, bool>(selectedTrain, true); return true;
                    default:
                        Console.WriteLine("Invalid input... Restarting booking...");
                        return false;
                }
            }
            return false;
        }
    }
}
