using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_PhaseII.Model
{
    public class Reservation
    {
        private static int autoIncrement;
        public int ID { get; set; }
        public DateTime date { get; set; }

        public Reservation()
        {
            autoIncrement++;
            ID = autoIncrement;
        }
    }
}
