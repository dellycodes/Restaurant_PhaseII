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
        // Necessary properties and attributes for a reservation.

        private static int autoIncrement;
        public int ID { get; set; }

        public static int TotalTables { get; set; } = 20;

        public int AvailableTables { get; set; } = 20;

        public Customer Customer { get; set; }

        public List<Customer> ReservedTables { get; set; } = new List<Customer>();

        public DateTime date;

        public DateTime time;

        public Reservation()
        {
            autoIncrement++;
            ID = autoIncrement;
        }

        public Reservation(int totalTables)
        {
            TotalTables = totalTables;
        }
        // Allow for outside use of total tables

        public bool IsAvailable()
        {
            return AvailableTables > 0;
        }
        // It's only available if there's more than 0 available tables

        public bool IsAvailable(int numTables)
        {
            return AvailableTables >= numTables;
        }

        public void MakeReservation(int TotalTables)
        {
            if (IsAvailable(TotalTables))
            {
                AvailableTables -= TotalTables;
            }
            else
            {
                throw new Exception("Not enough available tables.");
            }
        }
        // Removes an available table from the total tables when needed.

        public bool AddCustomer(Customer customer)
        {
            if (IsAvailable(TotalTables))
            {
                ReservedTables.Add(customer);
                AvailableTables -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        // When a reservation is added by any given customer, available tables is subtracted by 1.
    }
}
