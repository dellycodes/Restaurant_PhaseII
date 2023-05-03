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

        public int TotalTables = 20;

        public Customer Customer { get; set; }

        public List<Customer> ReservedTables { get; set; }

        public Staff AssignedStaff { get; set; }
        public DateTime date { get; set; }

        public Reservation()
        {
            autoIncrement++;
            ID = autoIncrement;
            ReservedTables = new List<Customer>();
        }

        public Reservation(int totalTables)
        {
            TotalTables = totalTables;
            ReservedTables = new List<Customer>();
        }

        public bool IsAvailable(int totalTables)
        {
            return (ReservedTables.Count < totalTables);
        }

        public bool AddCustomer(Customer customer)
        {
            if (IsAvailable(TotalTables))
            {
                ReservedTables.Add(customer);
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
