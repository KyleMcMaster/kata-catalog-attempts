using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Starter
{
    public class Reservation
    {
        public string Name { get; }
        public DateTimeOffset Date { get; }
        public int NumberOfDiners { get; }
        //public bool Accepted { get; } = false;

        public Reservation(Request request)
        {
            Name = request.Name;
            Date = request.Date;
            NumberOfDiners = request.NumberOfDiners;
        }
    }
}
