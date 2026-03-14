using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP06
{
    internal class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; }
        public double Fee { get; }

        public VIPTicket(int id, string movie, double price, bool loungeAccess, double fee)
            : base(id, movie, price)
        {
            LoungeAccess = loungeAccess;
            Fee = fee;
        }

        public override double CalculateFinalPrice()
        {
            return (Price + Fee) * 1.14;
        }

        public override string Category()
        {
            return "VIP";
        }
    }
}
