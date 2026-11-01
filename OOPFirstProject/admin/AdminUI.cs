using OOPFirstProject.bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.admin
{
    internal class AdminUI
    {
        AdminService service = new AdminService();
        BookingUI bookingUI = new BookingUI();

        public void AdminDriver()
        {
            bool loggedIn = Login();

            if (loggedIn == false)
            {
                return;
            }

            while (true)
            {
                Console.Clear();

                string option = AdminMenu();

                if (option == "1")
                {
                    bookingUI.ProductDriver();
                }
                else if (option == "2")
                {
                    ShowTotalClients();
                }
                else if (option == "3")
                {
                    ShowAverageBill();
                }
                else if (option == "4")
                {
                    break;
                }
            }
        }

        public bool Login()
        {
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                Console.Clear();
                Console.WriteLine("Admin Login Attempt " + attempt);

                Console.WriteLine("Enter Username");
                string username = Console.ReadLine();

                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();

                if (service.Login(username, password))
                {
                    Console.WriteLine("LOGIN SUCCESSFUL!");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                    Console.ReadKey();
                }
            }

            return false;
        }

        public void ShowTotalClients()
        {
            Console.WriteLine("Total clients: " + service.TotalClients());

            Console.ReadKey();
        }

        public void ShowAverageBill()
        {
            Console.WriteLine("Average bill per client: " + service.AverageBill());

            Console.ReadKey();
        }

        public string AdminMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========= ADMIN MENU ===========");
            Console.WriteLine("1. Bookings");
            Console.WriteLine("2. Total clients");
            Console.WriteLine("3. Average bill per client");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4. Logout");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter your choice: ");

            string adminChoice = Console.ReadLine();

            return adminChoice;
        }
    }
}

