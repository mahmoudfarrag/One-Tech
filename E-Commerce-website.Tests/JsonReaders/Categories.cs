using BL.ViewModels;
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

namespace E_Commerce_website.Tests.JsonReaders
{
    class Categories:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {


            System.IO.StreamReader reader = new StreamReader(@"D:\ITI\ASP Net MVC 5\MVC-Project-main\E-Commerce-website.Tests\JsonData\CategoryData.json");

            string json = reader.ReadToEnd();

            List<CategoryToObj> items = JsonConvert.DeserializeObject<List<CategoryToObj>>(json);
            foreach (var item in items)
            {
                CategoryViewModel c = new CategoryViewModel() { Name=item.Name };
                yield return new TestCaseData(c).Returns(item.expected);
            }
        }
    }
}
