using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_PhaseII.Model
{
    public class Waitlist
    {
        private List<CustomerReservation> reservations;
        private List<Customer> waitlist;

        public Waitlist()
        {
            reservations = new List<CustomerReservation>();
            waitlist = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }

}


