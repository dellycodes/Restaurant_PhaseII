using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_PhaseII.Model
{
    public class Customer
    {
        private static int autoIncrement;
        public int ID { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // All details needed for a user to sign up which allows them to view and make reservations.

        public Customer()
        {
            autoIncrement++;
            ID = autoIncrement;
        }

        
    }
}
