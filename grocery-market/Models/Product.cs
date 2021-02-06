using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery_market.Models
{
    public class Product
    {
        public Product()
        {
            Rules = new List<Rule>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
