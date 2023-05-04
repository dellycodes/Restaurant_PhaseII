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

        public static int TotalTables = 20;

        public int AvailableTables { get; set; } = 20;

        public Customer Customer { get; set; }

        public List<Customer> ReservedTables { get; set; } = new List<Customer>();

        public Staff AssignedStaff { get; set; }

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

        public bool IsAvailable()
        {
            return AvailableTables > 0;
        }

        public bool IsAvailable(int numTables)
        {
            return AvailableTables >= numTables;
        }

        public void MakeReservation(int numTables)
        {
            if (IsAvailable(numTables))
            {
                AvailableTables -= numTables;
            }
            else
            {
                throw new Exception("Not enough available tables.");
            }
        }

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

        public void AssignStaff(Staff staff)
        {
            AssignedStaff = staff;
        }
    }
}
