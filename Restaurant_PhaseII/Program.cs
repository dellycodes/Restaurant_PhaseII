using Restaurant_PhaseII.Model;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;

namespace Restaurant_PhaseII
{
    public class Program
    {
        private static Customers customers;
        private static List<Reservation> reservations;
        private static List<CustomerReservation> customerReservations;
        private static Customer authenticatedCustomer;
        public static List<Customer> ReservedTables { get; set; } = new List<Customer>();


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
                FirstName = "Delly",
                LastName = "Codes",
                Username = "dellycodes",
                Password = "password"
            };
            var c2 = new Customer
            {
                FirstName = "Laquan",
                LastName = "Mimsy",
                Username = "HumbleBeast",
                Password = "5678"
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

            while (!done)
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Open Reservations: 4 --- Book Reservation: 5 --- Clear Screen: c --- Quit: q ---");
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
                    case "5":
                        MakeReservationsMenu();
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
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password!");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");
            }
        }


        static void LogoutMenu()
        {
            if(authenticatedCustomer != null)
            {
                authenticatedCustomer = null;
                Console.WriteLine("Logged out!");
            }
            else
            {
                Console.WriteLine("You are not logged in!");
            }
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
                FirstName = firstName,
                LastName = lastName,
                Username = userName,
                Password = password
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

            Console.WriteLine("Available reservations:");
            Console.WriteLine(" ");

            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Today.AddDays(i);
                Console.WriteLine(date.ToString("D"));
                Console.WriteLine(" ");

                // Create a list of time slots for this day
                List<DateTime> timeSlots = new List<DateTime>();
                DateTime startTime = date.Date.AddHours(17);
                DateTime endTime = date.Date.AddHours(21);
                while (startTime < endTime)
                {
                    timeSlots.Add(startTime);
                    startTime = startTime.AddMinutes(60);
                }

                // Check each time slot for availability
                foreach (DateTime timeSlot in timeSlots)
                {
                    bool isAvailable = true;
                    foreach (var reservation in reservations)
                    {
                        if (reservation.date.Date == date.Date && reservation.time == timeSlot)
                        {
                            if (!reservation.IsAvailable(1))
                            {
                                isAvailable = false;
                                break;
                            }
                        }
                    }

                    if (isAvailable)
                    {
                        Console.WriteLine(timeSlot.ToString("t"));
                    }
                }
                Console.WriteLine();
            }
        }

        static void MakeReservationsMenu()
        {
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You must be logged in to make a reservation.");
                return;
            }

            Console.Write("Enter the date of your reservation (mm/dd/yyyy): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Invalid date format. Please enter a date in the format mm/dd/yyyy: ");
            }

            Console.Write("Enter the time of your reservation (h:mm): ");
            DateTime time;
            while (!DateTime.TryParse(Console.ReadLine(), out time))
            {
                Console.Write("Invalid time format. Please enter a time in the format h:mm: ");
            }

            // Check if the requested reservation date and time is available
            bool isAvailable = true;
            foreach (var reservation in reservations)
            {
                if (reservation.date == date && reservation.time == time && !reservation.IsAvailable())
                {
                    isAvailable = false;
                    break;
                }
            }

            if (isAvailable)
            {
                // Create a new reservation and add it to the list of reservations
                var newReservation = new Reservation
                {
                    date = date,
                    time = time,
                    ReservedTables = new List<Customer> { new Customer() }
                };

                reservations.Add(newReservation);

                // Update the total number of reserved tables for this date and time
                var reservedTables = reservations.Where(r => r.date == date && r.time == time).Sum(r => ReservedTables.Count);
                if (reservedTables >= Reservation.TotalTables)
                {
                    Console.WriteLine("Sorry, the requested time is fully booked.");
                    reservations.Remove(newReservation);
                }
                else
                {
                    // Create a new customer reservation and add it to the list of customer reservations
                    var newCustomerReservation = new CustomerReservation(authenticatedCustomer, newReservation);
                    customerReservations.Add(newCustomerReservation);

                    Console.WriteLine("Reservation created!");
                }
            }
            else
            {
                Console.WriteLine("Sorry, the requested date and time is not available.");
            }
        }
    }
}  