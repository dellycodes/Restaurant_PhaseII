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
            bool done = false;

            while (done)
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Reservations: 4 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignupMenu();
                        break;
                    case "4":
                        GetCurrentReservationsMenu();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Command!");
                        break;
                }
            }
        }


        static void LoginMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedCustomer = customers.Authenticate(username, password);
                if (authenticatedCustomer != null)
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.firstName}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password!");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.userName}");
            }
        }


        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out!");
        }

        static void SignupMenu()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newCustomer = new Customer
            {
                firstName = firstName,
                lastName = lastName,
                userName = userName,
                password = password
            };

            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");
        }


        static void GetCurrentReservationsMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }

            var reservationList = customerReservations.Where(o => o.customer.userName == authenticatedCustomer.userName);

            if(reservationList.Count() == 0)
            {
                Console.WriteLine("0 appointments found.");
            }
            else
            {
                foreach(var reservation in reservationList)
                {
                    Console.WriteLine(reservation.reservation.date);
                }
            }
        }
    }
}