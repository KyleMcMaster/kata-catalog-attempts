using LanguageExt;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Starter
{
    public class Restaurant
    {
        public int Capacity { get; }

        public List<Reservation> AcceptedReservations { get; }

        public Restaurant(int capacity)
        {
            this.Capacity = capacity;
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
