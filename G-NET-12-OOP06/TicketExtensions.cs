using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP06
{
    public static class TicketExtensions
    {
        public static string GenerateReceipt(this Ticket ticket)
        {
            return
    $@"========== RECEIPT ==========
  Movie    : {ticket.Movie}
  Type     : {ticket.GetType().Name}
  Price    : {ticket.Price}
  Final    : {ticket.CalculateFinalPrice():F2}
  Status   : {(ticket.IsBooked ? "Booked" : "Not Booked")}
=============================";
        }

        public static double TotalRevenue(this Ticket[] tickets)
        {
            return tickets.Sum(t => t.CalculateFinalPrice());
        }
    }
}
