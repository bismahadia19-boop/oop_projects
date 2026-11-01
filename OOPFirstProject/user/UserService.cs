using OOPFirstProject.bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.user
{
    internal class UserService
    {
        private UserRepo _repo = new UserRepo();
        private BookingService _bookingService = new BookingService();
        private BookingRepo _bookingRepo = new BookingRepo();

        public UserService() { }

        public BookingModel SearchByName(string name)
        {
            return _bookingService.SearchByName(name);
        }

        public void SaveFeedback(string message)
        {
            UserModel user = new UserModel(message);
            _repo.SaveFeedback(user);
        }

        // Return: -1 = record nahi mila, 0 = discount nahi mila, warna naya bill
        public bool ApplyDiscount(string name)
        {
            List<BookingModel> bookings = _bookingRepo.GetAllBookings();

            foreach (BookingModel booking in bookings)
            {
                if (booking.GetName() == name && booking.GetBill() > 4000)
                {
                    int newBill = booking.GetBill() * 95 / 100; // 5% discount

                    booking.SetBill(newBill);

                    _bookingRepo.SaveAllDataIntoFile(bookings);

                    return true;
                }
            }

            return false;
        }
    }
}

