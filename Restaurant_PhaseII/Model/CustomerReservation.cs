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
            if (reservation.IsAvailable())
            {
                reservation.AddReservation(customer);
                Console.WriteLine("{0} made a reservation for {1}.", customer, reservation.ToString("yyyy/MM/dd HH:mm"));
            }
            else
            {
                Console.WriteLine("{0} could not make a reservation for {1} because it is full.", customer.Name, reservation.Date.ToString("yyyy/MM/dd HH:mm"));
                waitlist.AddCustomer(customer);
            }
        }
    }
}

