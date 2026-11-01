using OOPFirstProject;
using OOPFirstProject.admin;
using OOPFirstProject.bookings;
using OOPFirstProject.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject
{
    internal class photography
    {
        public void start()
        {
            while (true)
            {
                Console.Clear();
                string choice = MainMenu();

                if (choice == "1")
                {
                    AdminUI adminUI = new AdminUI();
                    adminUI.AdminDriver();
                }
                else if (choice == "2")
                {
                    UserUI userUI = new UserUI();
                    userUI.UserDriver();
                }
                else if (choice == "3")
                {
                    break;
                }
            }
        }
        public string MainMenu()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("     PHOTOGRAPHY BUSINESS MANAGEMENT SYSTEM  ");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your choice ");
            string choice = Console.ReadLine();
            return choice;

        }


    }
}