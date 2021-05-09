using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_website.Tests.TestMappingClasses
{
   public class ReviewItem
    {
        public string Description { get; set; }

       
        public int rating { get; set; }


        public int productID { get; set; }



        public string userID { get; set; }
        public bool expectedValue { get; set; }
    }
}
