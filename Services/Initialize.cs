using System;
using System.Collections.Generic;
using System.Linq;
using Trainspotting.Models;

namespace Trainspotting.Services
{
    class Initialize
    {
        private List<TrainData> _currentData;

        public Initialize() { }
        public Initialize(List<TrainData> currentData)
        {
            _currentData = currentData;
        }

        public List<TrainData> FetchData()
        {
            if (_currentData == null)
            {
                DataUpload newUpload = new DataUpload();

                _currentData = newUpload.GetTextFile();
            }

            return _currentData;
        }

        public List<TrainData> UpdateSeats(TrainData updatedData)
        {

            _currentData[_currentData.IndexOf(updatedData)] = updatedData;

            return _currentData;
        }
    }
}
