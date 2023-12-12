using System;
using System.Collections.Generic;

namespace PostMachine
{
    public class Carriage
    {
        private int? locationIndex;
        private List<int> lastLocation = new List<int>();

        public Carriage(int locationIndex)
        {
            this.locationIndex = locationIndex;
        }

        public void CarriageRight()
        {
            if (locationIndex.HasValue)
            {
                lastLocation.Add(locationIndex.Value);
                locationIndex += 1;
            }
        }

        public void CarriageLeft()
        {
            if (locationIndex.HasValue)
            {
                lastLocation.Add(locationIndex.Value);
                locationIndex -= 1;
            }
        }

        public void SetNewLocation(int index)
        {
            if (locationIndex.HasValue)
            {
                lastLocation.Add(locationIndex.Value);
                locationIndex = index;
            }
        }

        public int GetCarriageLocation()
        {
            return locationIndex ?? 0;
        }

    }
}
