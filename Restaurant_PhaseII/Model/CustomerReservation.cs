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
	}
}

