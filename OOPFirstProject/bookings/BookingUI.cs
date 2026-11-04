using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.bookings
{
    internal class BookingUI
    {
        BookingService service = new BookingService();
        public void ProductDriver()
        {
            while (true)
            {
                Console.Clear();

                string option = BookingMenu();

                if (option == "1")
                {
                    BookingModel booking = TakeInput();
                    service.SaveBooking(booking);
                }
                else if (option == "2")
                {
                    UpdateBooking();
                }
                else if (option == "3")
                {
                    DeleteBooking();
                }
                else if (option == "4")
                {
                    ShowAllBookings();
                }
                else if (option == "5")
                {
                    SearchBooking();
                }
                else if (option == "6")
                {
                    Sorting();
                }
                else if (option == "7")
                {
                    ShowTotalRevenue();
                }
                else if (option == "8")
                {
                    ShowHighestPayingClient();
                }
                else if (option == "9")
                {
                    ShowLowestPayingClient();
                }
                else if(option=="10")
                    {
                    
                }
                else if (option == "10")
                {
                    break;
                }
            }
        }

        public void UpdateBooking()
        {
            Console.WriteLine("Enter name of the client to update");
            string name = Console.ReadLine();

            Console.WriteLine("Enter new shoot type");
            string shoottype = Console.ReadLine();

            Console.WriteLine("Enter new packages");
            string packages = Console.ReadLine();

            Console.WriteLine("Enter new hours");
            int hours = int.Parse(Console.ReadLine());

            bool isUpdated = service.UpdateBooking(name, shoottype, packages, hours);

            if (isUpdated)
            {
                Console.WriteLine("Booking updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update booking.");
            }

            Console.ReadKey();
        }

        public void DeleteBooking()
        {
            Console.WriteLine("Enter name of the client to delete");
            string name = Console.ReadLine();

            bool isDeleted = service.DeleteBooking(name);

            if (isDeleted)
            {
                Console.WriteLine("Booking deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete booking.");
            }

            Console.ReadKey();
        }

        public void SearchBooking()
        {
            Console.WriteLine("Enter client name to search");
            string name = Console.ReadLine();

            BookingModel booking = service.SearchByName(name);

            if (booking != null)
            {
                Console.WriteLine("Booking Found!");
                Console.WriteLine(booking.ToString());
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }

            Console.ReadKey();
        }

        public void ShowAllBookings()
        {
            List<BookingModel> bookings = service.GetAllBookings();

            foreach (BookingModel booking in bookings)
            {
                Console.WriteLine(booking.ToString());
            }

            Console.ReadKey();
        }

        public void Sorting()
        {
            List<BookingModel> bookings = service.SortBookings();

            foreach (BookingModel booking in bookings)
            {
                Console.WriteLine(booking.ToString());
            }

            Console.ReadKey();
        }

        public void ShowTotalRevenue()
        {
            int total = service.TotalRevenue();

            Console.WriteLine("Total revenue: " + total);

            Console.ReadKey();
        }

        public void ShowLowestPayingClient()
        {
            BookingModel booking = service.LowestPayingClient();

            if (booking == null)
            {
                Console.WriteLine("No bookings found.");
            }
            else
            {
                Console.WriteLine(booking.ToString());
            }

            Console.ReadKey();
        }

        public void ShowHighestPayingClient()
        {
            BookingModel booking = service.HighestPayingClient();

            if (booking == null)
            {
                Console.WriteLine("No bookings found.");
            }
            else
            {
                Console.WriteLine(booking.ToString());
            }

            Console.ReadKey();
        }

        public BookingModel TakeInput()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter shoot type");
            string shoottype = Console.ReadLine();

            Console.WriteLine("Enter Packages");
            string packages = Console.ReadLine();

            Console.WriteLine("Enter Hours");
            int hours = int.Parse(Console.ReadLine());

            int bill = service.CalculateBill(shoottype, packages, hours);

            Console.WriteLine("Your bill = " + bill);

            BookingModel booking = new BookingModel(name, shoottype, packages, hours, bill);

            return booking;
        }
        public void page(int page)
        {
            Console.WriteLine("How many records to show on a page ");
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter F to show next page");
            char ch = char.Parse(Console.ReadLine());
            Console.WriteLine("Please enter N to show next page");
            char ch1 = char.Parse(Console.ReadLine());
            Console.WriteLine("Please enter p to show previous page ");
            char ch2= char.Parse(Console.ReadLine());
            Console.WriteLine("Please enter L to show the last page ");
            char ch3 = char.Parse(Console.ReadLine());
            Console.WriteLine("Please enter X to show the exit ");
            char ch4 = char.Parse(Console.ReadLine());
        }
        public void quickfilter()
        {
        }
        public string BookingMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========= BOOKING MENU ===========");
            Console.WriteLine("1. Add Booking");
            Console.WriteLine("2. Update Bookings");
            Console.WriteLine("3. Delete Booking");
            Console.WriteLine("4. Show all Bookings");
            Console.WriteLine("5. Search Booking");
            Console.WriteLine("6. Sorting");
            Console.WriteLine("7. Total revenue");
            Console.WriteLine("8. Highest paying client");
            Console.WriteLine("9. Lowest paying client");
            Console.WriteLine("10. panginated layer ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("10. Back");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter your choice: ");

            string bookingChoice = Console.ReadLine();

            return bookingChoice;
        }
    }
}

