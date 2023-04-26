using Restaurant_PhaseII.Model;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Restaurant_PhaseII
{
    public class Program
    {
        private static Customers customers;
        private static List<Reservation> reservations;
        private static List<CustomerReservation> customerReservations;
        private static Customer authenticatedCustomer;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            var c1 = new Customer
            {
                firstName = "Delly",
                lastName = "Codes",
                userName = "dellycodes",
                password = "password"
            };
            var c2 = new Customer
            {
                firstName = "Laquan",
                lastName = "Mimsy",
                userName = "HumbleBeast",
                password = "5678"
            };
            var a1 = new Reservation();
            var a2 = new Reservation();
            var a3 = new Reservation();

            var ca1 = new CustomerReservation(c1, a1);
            var ca2 = new CustomerReservation(c1, a2);
            var ca3 = new CustomerReservation(c2, a3);

            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            reservations = new List<Reservation>();
            reservations.Add(a1);
            reservations.Add(a2);
            reservations.Add(a3);

            customerReservations = new List<CustomerReservation>();
            customerReservations.Add(ca1);
            customerReservations.Add(ca2);
            customerReservations.Add(ca3);



        }

        static void Menu()
        {

        }
    }
}