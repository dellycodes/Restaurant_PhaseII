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

        public void MakeReservation(Customer customer, Reservation reservation, int totalTables)
        {
            if (reservation.ReservedTables.Count >= totalTables)
            {
                Console.WriteLine($"Cannot make a reservation for {reservation.date.ToString("yyyy/MM/dd HH:mm")} because it is full.");
            }
            else
            {
                reservation.AddCustomer(customer);
                Console.WriteLine($"{customer.FirstName} {customer.LastName} made a reservation for {reservation.date.ToString("yyyy/MM/dd HH:mm")}.");
            }
        }

    }
}

