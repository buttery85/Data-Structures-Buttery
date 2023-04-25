using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectButtery
{
    public class CarList
    {
        public string make, model, color;
        public int stockNumber, year;
        public decimal mileage, price;

        public CarList(int stocknumber, int year, string make, string model, string color, decimal mileage, decimal price)
        {
            this.stockNumber = stocknumber;
            this.year = year;
            this.make = make.ToUpper();
            this.model = model.ToUpper();
            this.color = color.ToUpper();
            this.mileage = mileage;
            this.price = price;
        }
    }
}