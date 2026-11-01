using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.bookings
{
    internal class BookingService
    {
        private BookingRepo _repo = new BookingRepo();
        public BookingService() { }

        public List<BookingModel> GetAllBookings()
        {
            return _repo.GetAllBookings();
        }

        public void SaveBooking(BookingModel booking)
        {
            _repo.SaveInFile(booking);
        }

        public BookingModel SearchByName(string name)
        {
            foreach (BookingModel booking in _repo.GetAllBookings())
            {
                if (booking.GetName() == name)
                {
                    return booking;
                }
            }

            return null;
        }

        public bool UpdateBooking(string name, string shoottype, string packages, int hours)
        {
            List<BookingModel> bookings = _repo.GetAllBookings();

            foreach (BookingModel booking in bookings)
            {
                if (booking.GetName() == name)
                {
                    int bill = CalculateBill(shoottype, packages, hours);

                    booking.SetShootType(shoottype);
                    booking.SetPackages(packages);
                    booking.SetHours(hours);
                    booking.SetBill(bill);

                    _repo.SaveAllDataIntoFile(bookings);

                    return true;
                }
            }

            return false;
        }

        // Bill calculate
        public int CalculateBill(string shoottype, string packages, int hours)
        {
            int rate = 0;

            if (shoottype == "Wedding")
            {
                if (packages == "Premium")
                    rate = 1000;
                else if (packages == "Elite")
                    rate = 1500;
                else if (packages == "Basic")
                    rate = 500;
            }
            else if (shoottype == "Solo")
            {
                if (packages == "Premium")
                    rate = 500;
                else if (packages == "Elite")
                    rate = 800;
                else if (packages == "Basic")
                    rate = 300;
            }
            else if (shoottype == "Event")
            {
                if (packages == "Premium")
                    rate = 700;
                else if (packages == "Elite")
                    rate = 1200;
                else if (packages == "Basic")
                    rate = 400;
            }

            return hours * rate;
        }

        public bool DeleteBooking(string name)
        {
            List<BookingModel> bookings = _repo.GetAllBookings();

            int count = 0;

            foreach (BookingModel booking in bookings)
            {
                if (booking.GetName() == name)
                {
                    bookings.RemoveAt(count);

                    _repo.SaveAllDataIntoFile(bookings);

                    return true;
                }

                count++;
            }

            return false;
        }

        // Sorting
        public List<BookingModel> SortBookings()
        {
            List<BookingModel> bookings = _repo.GetAllBookings();

            for (int i = 0; i < bookings.Count; i++)
            {
                for (int j = 0; j < bookings.Count - 1; j++)
                {
                    if (bookings[j].GetBill() > bookings[j + 1].GetBill())
                    {
                        BookingModel temp = bookings[j];

                        bookings[j] = bookings[j + 1];

                        bookings[j + 1] = temp;
                    }
                }
            }

            return bookings;
        }

        public int TotalRevenue()
        {
            List<BookingModel> bookings = _repo.GetAllBookings();

            int total = 0;

            foreach (BookingModel booking in bookings)
            {
                total += booking.GetBill();
            }

            return total;
        }

        public BookingModel LowestPayingClient()
        {
            List<BookingModel> bookings = _repo.GetAllBookings();

            if (bookings.Count == 0)
            {
                return null;
            }

            BookingModel lowest = bookings[0];

            for (int i = 1; i < bookings.Count; i++)
            {
                if (bookings[i].GetBill() < lowest.GetBill())
                {
                    lowest = bookings[i];
                }
            }

            return lowest;
        }

        public BookingModel HighestPayingClient()
        {
            List<BookingModel> bookings = _repo.GetAllBookings();

            if (bookings.Count == 0)
            {
                return null;
            }

            BookingModel highest = bookings[0];

            for (int i = 1; i < bookings.Count; i++)
            {
                if (bookings[i].GetBill() > highest.GetBill())
                {
                    highest = bookings[i];
                }
            }

            return highest;
        }
    }
}

