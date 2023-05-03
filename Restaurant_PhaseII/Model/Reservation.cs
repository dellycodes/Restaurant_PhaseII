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

        static public int TotalTables = 20;

        public Customer Customer { get; set; }

        public Staff AssignedStaff { get; set; }
        public DateTime date { get; set; }

        public Reservation()
        {
            autoIncrement++;
            ID = autoIncrement;
        }

        public bool IsAvailable(Customer c, int TotalTables)
        {
            return (c.Count < TotalTables);
        }

        public void AssignStaff(Staff staff)
        {
            AssignedStaff = staff;
        }
    }
}
