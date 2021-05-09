using E_Commerce_website.Tests.TestMappingClasses;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_website.Tests
{
    class ReviewsItems:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {


            StreamReader reader = new StreamReader(@"D:\ITI\ASP Net MVC 5\MVC-Project-main\E-Commerce-website.Tests\JsonData\ReviewsData.json");

            string json = reader.ReadToEnd();

            List<ReviewItem> items = JsonConvert.DeserializeObject<List<ReviewItem>>(json);
            foreach (var item in items)
            {
                yield return new TestCaseData(item.productID, item.userID, item.Description,item.rating).Returns(item.expectedValue);
            }
        }
    }
}
