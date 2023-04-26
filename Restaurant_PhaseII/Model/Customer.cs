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
        public string userName {  get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Customer()
        {
            autoIncrement++;
            ID = autoIncrement;
        }
    }
}
