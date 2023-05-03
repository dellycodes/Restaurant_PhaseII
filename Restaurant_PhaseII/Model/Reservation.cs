using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant_PhaseII.Model
{
    public class Reservation
    {
        private static int autoIncrement;
        public int ID { get; set; }

        public Customer Customer { get; set; }

        public int PartySize { get; set; }

        public Staff AssignedStaff { get; set; }
        public DateTime date { get; set; }

        public bool IsAvailable(int partySize)
        {
            // Check if reservation is available based on party size and existing customers
            int totalGuests = Customers.Sum(c => PartySize);
            return PartySize >= partySize && totalGuests + partySize <= PartySize;
        }
        public void AddReservation(Customer customer)
        {
            Customers.Add(customer);
        }

        public Reservation()
        {
            autoIncrement++;
            ID = autoIncrement;
        }

        public Reservation(Customer customer, int partySize, DateTime date)
        {
            autoIncrement++;
            ID = autoIncrement;
            Customer = customer;
            PartySize = partySize;
            this.date = date;
            Customers.Add(customer);
        }

        public void AssignStaff(Staff staff)
        {
            AssignedStaff = staff;
        }
    }
}
