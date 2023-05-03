using System;
namespace Restaurant_PhaseII.Model
{
	public class CustomerReservation
	{
		public Customer customer { get; set; }
		public Reservation reservation { get; set; }

		public CustomerReservation(Customer c, Reservation r)
		{
			customer = c;
			reservation = r;
		}

        public void MakeReservation(Waitlist waitlist)
        {
            if (!reservation.IsAvailable())
            {
               waitlist.AddCustomer(customer);
                Console.WriteLine($"{customer} could not make a reservation for {reservation.date} because it is full.");
            }
            else
            {
                reservation.AddReservation(customer);
                Console.WriteLine($"{customer} made a reservation for {reservation.date.ToString("yyyy/MM/dd HH:mm")}."));
                
            }
        }
    }
}

