using System;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_website.Tests.TestMappingClasses;
using NUnit.Framework;
using System.IO;
using BL.ViewModels;

namespace E_Commerce_website.Tests.JsonReaders
{
   public class Product :IEnumerable
    {

        public IEnumerator GetEnumerator()
        {


            System.IO.StreamReader reader = new StreamReader(@"D:\ITI\ASP Net MVC 5\MVC-Project-main\E-Commerce-website.Tests\JsonData\ProductData.json");

            string json = reader.ReadToEnd();

            List<ProductToObj> items = JsonConvert.DeserializeObject<List<ProductToObj>>(json);
            foreach (var item in items)
            {
                ProductViewModel P = new ProductViewModel() { Color = item.Color, Discount = item.Discount, Name = item.Name, Description = item.Description, Price = item.Price, Quantity = item.Quantity };
                yield return new TestCaseData(P).Returns(item.Expected);
            }
        }
    }
}
