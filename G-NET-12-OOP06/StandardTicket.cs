using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP06
{
    internal class StandardTicket : Ticket
    {

        public string Seat { get; }

        public StandardTicket(int id, string movie, double price, string seat)
            : base(id, movie, price)
        {
            Seat = seat;
        }

        public override double CalculateFinalPrice()
        {
            return Price * 1.14;
        }

        public override string Category()
        {
            return "Standard";
        }

    }
}
