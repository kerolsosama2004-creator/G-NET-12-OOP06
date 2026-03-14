using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP06
{
    public partial class Cinema
    {
        private List<Ticket> tickets = new List<Ticket>();

        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }

        public Ticket[] GetTickets()
        {
            return tickets.ToArray();
        }

        public void OpenCinema()
        {
            Console.WriteLine("=== Cinema Opened ===");
            Console.WriteLine("Projector ON");
            Console.WriteLine();
        }

        public void CloseCinema()
        {
            Console.WriteLine();
            Console.WriteLine("Projector OFF");
            Console.WriteLine("=== Cinema Closed ===");
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("--- All Tickets (from Cinema.Reporting) ---");

            foreach (var t in tickets)
            {
                Console.WriteLine(
                    $"[Ticket #{t.Id}] {t.Movie} | {t.Category()} | " +
                    $"Price: {t.Price} | Final: {t.CalculateFinalPrice():F2} | " +
                    $"Booked: {(t.IsBooked ? "Yes" : "No")}"
                );
            }

            Console.WriteLine();
        }

    }
}
