using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_PhaseII.Model
{
   
        public class Staff
        {
            public int Id { get; set; }
            public string Name { get; set; }
           

            public Staff(int id, string name, string role)
            {
                Id = id;
                Name = name;
               
            }
        }

    }

