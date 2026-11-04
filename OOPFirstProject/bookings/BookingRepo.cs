using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstProject.bookings
{
    internal class BookingRepo
    {
        private string file = "bookings.txt";

        public BookingRepo() { }

        public void SaveInFile(BookingModel booking)
        {


            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(booking.ToString());
            }
        }

        public void SaveAllDataIntoFile(List<BookingModel> bookings)
        {
            File.WriteAllText(file, string.Empty);

            foreach (BookingModel booking in bookings)
            {
                SaveInFile(booking);
            }
        }

        public List<BookingModel> GetAllBookings()
        {
            List<BookingModel> bookingsList = new List<BookingModel>();

            if (!File.Exists(file))
            {
                return bookingsList;
            }

            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";

                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string name = parts[0];
                    string shoottype = parts[1];
                    string packages = parts[2];
                    int hours = int.Parse(parts[3]);
                    int bill = int.Parse(parts[4]);

                    BookingModel booking = new BookingModel(name, shoottype, packages, hours, bill);

                    bookingsList.Add(booking);
                }
            }

            return bookingsList;
        }
    }
}

