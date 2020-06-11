using Laboratorium4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Laboratorium4
{
    public class SearchHelper
    {

            HelperClass initialList = new HelperClass();

        public void MatchProduct(string productName)
        {
            IEnumerable<Product> products = initialList.products;

            //Nareerat
            Console.WriteLine("Enter the name of the product");
            string pname = Console.ReadLine();
            var query = products.SingleOrDefault(x => x.ProductName == productName);
            string inputSearch = Console.ReadLine();
            if (pname == inputSearch)
            {
                Console.WriteLine("You found" + productName);
            }
            else
            {
                Console.WriteLine("none of products were found");
            }

        }

        public void SearchUsingRegex()
        {
            IEnumerable<Product> products = initialList.products;

            //Niloufar 
            var searchPhrase = from s in  products
                               where s.ProductName == "Home Appliences"
                               select s;
            Console.WriteLine("Please eneter your search term: ");
            var userInput = Console.ReadLine().ToLower();
            string pat = @"^.*(\bappliences\b)?.*$";

            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            Match m = r.Match(userInput);
            int matchCount = 0;
            while (m.Success)
            {
                Console.WriteLine("Number of Matches\t" + (++matchCount));
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    Console.WriteLine("Group" + i + "='" + g + "'");
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        System.Console.WriteLine("Capture" + j + "='" + c + "', Position=" + c.Index);
                    }
                }
                m = m.NextMatch();

            }
        }

        //Josh
        public List<Product> SearchForProductByName(string searchString)
        {
            IEnumerable<Product> products = initialList.products;

            var searchResults = products.Where
                (p => p.ProductName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            return (List<Product>)searchResults;
        }


    }
}
