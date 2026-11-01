using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPFirstProject.bookings
{
    internal class BookingModel
    {
        private string name;
        private string shoottypye;
        private string packages;
        private int hours;
        private int bill;
        public BookingModel(string name, string shoottypye, string packages, int hours, int bill)
        {
            this.name = name;
            this.shoottypye = shoottypye;
            this.packages = packages;
            this.hours = hours;
            this.bill = bill;
        }

        public string SetName(string name)
        {
            this.name = name;
            return name;
        }

        public string GetName()
        {
            return name;
        }

        public string SetShootType(string shoottypye)
        {
            this.shoottypye = shoottypye;
            return shoottypye;
        }

        public string GetShootType()
        {
            return shoottypye;
        }

        public string SetPackages(string packages)
        {
            this.packages = packages;
            return packages;
        }

        public string GetPackages()
        {
            return packages;
        }

        public int SetHours(int hours)
        {
            this.hours = hours;
            return hours;
        }

        public int GetHours()
        {
            return hours;
        }

        public int SetBill(int bill)
        {
            this.bill = bill;
            return bill;
        }

        public int GetBill()
        {
            return bill;
        }

        public override string ToString()
        {
            return $"{name},{shoottypye},{packages},{hours},{bill}";
        }
    }
}
    
