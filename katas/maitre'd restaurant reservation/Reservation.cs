using System;

namespace Kata.Starter
{
    public class Reservation
    {
        public string Name { get; }
        public DateTimeOffset Date { get; }
        public int NumberOfDiners { get; }

        public Reservation(Request request)
        {
            Name = request.Name;
            Date = request.Date;
            NumberOfDiners = request.NumberOfDiners;
        }
    }
}
