using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Laboratorium4
{
    public class SearchHelper
    {
        
        public void Run()
        {




            //Niloufar 
            var searchPhrase = from s in new HelperClass().products
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

    }
}
