namespace NightlifeEntertainment
{
    using System.Collections.Generic;

    public class SportHall : Venue
    {
        public SportHall(string name, string location, int numberOfSeats)
            : base(
                name, 
                location, 
                numberOfSeats, 
                new List<PerformanceType> { PerformanceType.Sport, PerformanceType.Concert })
        {
        }
    }
}