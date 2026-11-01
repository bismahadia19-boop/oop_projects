using OOPFirstProject.bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.user
{
    internal class UserUI
    {
        UserService service = new UserService();

        public void UserDriver()
        {
            while (true)
            {
                Console.Clear();

                string option = UserMenu();

                if (option == "1")
                {
                    ViewMyDetails();
                }
                else if (option == "2")
                {
                    SearchBooking();
                }
                else if (option == "3")
                {
                    ShowPackages();
                }
                else if (option == "4")
                {
                    ShowShootTypes();
                }
                else if (option == "5")
                {
                    CheckBill();
                }
                else if (option == "6")
                {
                    Discount();
                }
                else if (option == "7")
                {
                    TakeFeedback();
                }
                else if (option == "8")
                {
                    break;
                }
            }
        }

        public void ViewMyDetails()
        {
            Console.WriteLine("Enter your name to see your details");
            string name = Console.ReadLine();

            BookingModel booking = service.SearchByName(name);

            if (booking != null)
            {
                Console.WriteLine("Name: " + booking.GetName());
                Console.WriteLine("Shoot Type: " + booking.GetShootType());
                Console.WriteLine("Package: " + booking.GetPackages());
                Console.WriteLine("Hours: " + booking.GetHours());
                Console.WriteLine("Bill: " + booking.GetBill());
            }
            else
            {
                Console.WriteLine("No Record Found");
            }

            Console.ReadKey();
        }

        public void SearchBooking()
        {
            Console.WriteLine("Enter name to search");
            string name = Console.ReadLine();

            BookingModel booking = service.SearchByName(name);

            if (booking != null)
            {
                Console.WriteLine(booking.GetName() + " " + booking.GetBill());
            }
            else
            {
                Console.WriteLine("No Record Found");
            }

            Console.ReadKey();
        }

        public void ShowPackages()
        {
            Console.WriteLine("Price per hour");
            Console.WriteLine("Shoot\tBasic\tElite\tPremium");
            Console.WriteLine("Wedding\t500\t1500\t1000");
            Console.WriteLine("Solo\t300\t800\t500");
            Console.WriteLine("Event\t400\t1200\t700");

            Console.ReadKey();
        }

        public void ShowShootTypes()
        {
            Console.WriteLine("Shoot types:");
            Console.WriteLine("Event");
            Console.WriteLine("Solo");
            Console.WriteLine("Wedding");

            Console.ReadKey();
        }

        public void CheckBill()
        {
            Console.WriteLine("Enter name to check your bill");
            string name = Console.ReadLine();

            BookingModel booking = service.SearchByName(name);

            if (booking != null)
            {
                Console.WriteLine("Your Bill = " + booking.GetBill());
            }
            else
            {
                Console.WriteLine("No Record Found");
            }

            Console.ReadKey();
        }

        public void Discount()
        {
            Console.WriteLine("Enter your name to get discount");
            string name = Console.ReadLine();

            BookingModel booking = service.SearchByName(name);

            if (booking == null)
            {
                Console.WriteLine("No Record Found");
            }
            else
            {
                bool isApplied = service.ApplyDiscount(name);

                if (isApplied)
                {
                    Console.WriteLine("5% discount applied");
                    Console.WriteLine("New bill is " + service.SearchByName(name).GetBill());
                }
                else
                {
                    Console.WriteLine("No discount");
                }
            }

            Console.ReadKey();
        }
        public void TakeFeedback()
        {
            Console.WriteLine("Your Feedback");
            string message = Console.ReadLine();

            service.SaveFeedback(message);

            Console.WriteLine("Saved: " + message);

            Console.ReadKey();
        }

        public string UserMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========= USER MENU ============");
            Console.WriteLine("1. View Your Booking Details");
            Console.WriteLine("2. Search Your Bookings");
            Console.WriteLine("3. View All Packages");
            Console.WriteLine("4. View All Shoot Types");
            Console.WriteLine("5. Check Your Bill");
            Console.WriteLine("6. Discount");
            Console.WriteLine("7. Feedback");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Logout");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter your choice: ");

            string userChoice = Console.ReadLine();

            return userChoice;
        }
    }
}

