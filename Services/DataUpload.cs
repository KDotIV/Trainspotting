using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trainspotting.Helpers;
using Trainspotting.Models;

namespace Trainspotting.Services
{
    public class DataUpload
    {
        public List<TrainData> GetTextFile()
        {
            try
            {
                string directory = Directory.GetCurrentDirectory();

                string filePath = directory + "\\TrainData\\Train Data.txt";

                List<string> lines = File.ReadAllLines(filePath).ToList();
                List<TrainData> data = new List<TrainData>();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');

                    if (entries.Length > 3 || entries.Length <= 2)
                    {
                        Console.Write("Data Entry incorrect");
                        continue;
                    }

                    List<Seat> newSeats = GenerateSeats(Int32.Parse(entries[2]));
                    if (newSeats == null)
                    {
                        Console.WriteLine("Entry was not added");
                        continue;
                    }


                    TrainData newTrainData = new TrainData(HelperFunctions.GenerateID(),entries[0], entries[1], newSeats);

                    data.Add(newTrainData);
                }

                return data;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return null;
            }
        }

        public List<Seat> GenerateSeats(int numOfSeats)
        {
            if (numOfSeats < 0)
            {
                Console.WriteLine("Seats cannot be less than 0");
                return null;
            }

            List<Seat> newSeats = new List<Seat>();

            int midPoint = numOfSeats / 2;

            for (int i = 0; i < midPoint; i++)
            {
                
                Seat newAisleSeat = new Seat
                {
                    seatNum= i,
                    Occupied = false,
                    SeatType = SeatType.Aisle
                };

                newSeats.Add(newAisleSeat);
            }
            for (int i = midPoint; i < numOfSeats; i++)
            {
                Seat newWindowSeat = new Seat
                {
                    seatNum= i,
                    Occupied = false,
                    SeatType = SeatType.Window
                };

                newSeats.Add(newWindowSeat);
            }

            return newSeats;
        }
    }
}
