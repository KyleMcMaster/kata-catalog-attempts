using System;

namespace Kata.Starter
{
    public class Request
    {
        public string Name { get; }
        public DateTimeOffset Date { get; }
        public int NumberOfDiners { get; }

        public Request(string name, DateTimeOffset date, int numberOfDiners)
        {
            Name = name;
            Date = date;
            NumberOfDiners = numberOfDiners;
        }

    }
}
