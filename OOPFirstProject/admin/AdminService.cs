using OOPFirstProject.bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.admin
{
    internal class AdminService
    {
        private AdminRepo _repo = new AdminRepo();
        private BookingService _bookingService = new BookingService();

        public AdminService() { }

        public bool Login(string username, string password)
        {
            AdminModel admin = _repo.GetAdmin();

            if (username == admin.GetUsername() && password == admin.GetPassword())
            {
                return true;
            }

            return false;
        }

        public int TotalClients()
        {
            return _bookingService.GetAllBookings().Count;
        }

        public int AverageBill()
        {
            int count = _bookingService.GetAllBookings().Count;

            if (count == 0)
            {
                return 0;
            }

            return _bookingService.TotalRevenue() / count;
        }
    }
}
