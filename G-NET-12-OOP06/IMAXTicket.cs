using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP06
{
    internal class IMAXTicket : Ticket
    {
        public bool Is3D { get; }

        public IMAXTicket(int id, string movie, double price, bool is3D)
            : base(id, movie, price)
        {
            Is3D = is3D;
        }

        public override double CalculateFinalPrice()
        {
            return Price * 1.14;
        }

        public override string Category()
        {
            return "IMAX";
        }
    }
}
