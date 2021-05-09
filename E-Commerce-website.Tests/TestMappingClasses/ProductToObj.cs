using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_website.Tests.TestMappingClasses
{
   public class ProductToObj
    {
        public int ID { get; set; }


        public string Name { get; set; }



        public double Price { get; set; }


        public string Description { get; set; }

        public string Color { get; set; }


        public double Discount { get; set; }


        public string image { get; set; }


        public int Quantity { get; set; }
        public bool Expected { get; set; }

    }
}
