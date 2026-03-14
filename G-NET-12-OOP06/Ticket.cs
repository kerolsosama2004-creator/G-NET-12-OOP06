using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP06
{
    public abstract class Ticket
    {
        public int Id { get; }
        public string Movie { get; }
        public double Price { get; }
        public bool IsBooked { get; private set; }

        protected Ticket(int id, string movie, double price)
        {
            Id = id;
            Movie = movie;
            Price = price;
        }

        // ABSTRACT → every ticket must implement its own pricing logic
        public abstract double CalculateFinalPrice();

        // VIRTUAL → can be overridden if needed
        public virtual string Category()
        {
            return "General";
        }

        // CONCRETE → shared behavior
        public void Book()
        {
            IsBooked = true;
        }

        public void Cancel()
        {
            IsBooked = false;
        }
    }
}
