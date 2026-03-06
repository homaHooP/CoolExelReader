using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class product
    {
        public string name {  get; set; }
        public double price { get; set; }
        public int number { get; set; }

        public product() { }

        public product(string name, double price, int number)
        {
            this.name = name;
            this.price = price;
            this.number = number;
        }
    }
}
