using System;
namespace Restaurant_PhaseII.Model
{
	public class CustomerReservation
	{
		Customer customer { get; set; }
		Reservation reservation { get; set; }

		public CustomerReservation(Customer c, Reservation r)
		{
			customer = c;
			reservation = r;
		}
	}
}

