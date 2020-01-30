using LanguageExt;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

namespace Kata.Starter
{
    public class Restaurant
    {
        public int Capacity { get; }

        public List<Reservation> AcceptedReservations { get; }

        public Restaurant(int capacity)
        {
            this.Capacity = capacity;
            this.AcceptedReservations = new List<Reservation>();
        }

        public Option<Reservation> ProcessRequest(Request request)
        {
            var currentCapacity = AcceptedReservations
                .Where(ar => ar.Date.Date == request.Date.Date)
                .Select(ar => ar.NumberOfDiners)
                .Sum();

            if (currentCapacity + request.NumberOfDiners <= this.Capacity)
            {
                var acceptedReservation = new Reservation(request);
                AcceptedReservations.Add(acceptedReservation);
                return Some(acceptedReservation);
            }

            return None;
        }
    }
}
