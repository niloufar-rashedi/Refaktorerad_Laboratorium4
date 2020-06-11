using Laboratorium4.Models;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Laboratorium4
{
    public class HelperClass 
    {
        Producer p1 = new Producer("ICA");
        Producer p2 = new Producer("Clas Ohlson");

        public IEnumerable<Product> products = new List<Product>(){

            (new Product()
            {
                ProductName = "Carpet",
                ProductId = 1,
                Price = 1229.9m,
                Shop = new List<Shop>()
                    {
                        new Shop()
                            {
                                ShopId = 0,
                                ShopCity = "Lidköping"
                            },
                        new Shop()
                        {
                            ShopId = 1,
                            ShopCity = "Borås"
                        },
                        new Shop()
                        {
                            ShopId = 3,
                            ShopCity = "Stockholm"
                        }
                    },
                _producer = new Producer("ICA")
    }),
            (new Product()
            {
                ProductName = "Shampoo",
                ProductId = 2,
                Price = 189.9m,
                Shop = new List<Shop>()
                    {
                        new Shop()
                        {
                            ShopId = 4,
                            ShopCity = "Kalmar"
                        },
                        new Shop()
                        {
                            ShopId = 1,
                            ShopCity = "Borås"
                        },
                        new Shop()
                        {
                            ShopId = 3,
                            ShopCity = "Stockholm"
                        }
                    },
                _producer = new Producer("Clas Ohlson")
            }),
            (new Product()
            {
                ProductName = "Towel",
                ProductId = 8,
                Price = 26.9m,
                Shop = new List<Shop>()
                    {
                        new Shop()
            {
            ShopId = 4,
                                ShopCity = "Kalmar"
                            },
                        new Shop()
            {
            ShopId = 1,
                            ShopCity = "Borås"
                        },
                        new Shop()
            {
            ShopId = 3,
                            ShopCity = "Stockholm"
                        }
            },
                _producer = new Producer("Clas Ohlson")
            }),
            (new Product()
            {
                ProductName = "Tea Bag",
                ProductId = 4,
                Price = 89.9m,
                Shop = new List<Shop>()
                    {
                        new Shop()
        {
            ShopId = 2,
                                ShopCity = "Lund"
                            },
                        new Shop()
        {
            ShopId = 1,
                            ShopCity = "Borås"
                        },
                        new Shop()
        {
            ShopId = 3,
                            ShopCity = "Stockholm"
                        },
                        new Shop()
        {
            ShopId = 4,
                             ShopCity = "Kalmar"
                         },

                    },
                _producer = new Producer("ICA")
            }),
                    (new Product()
            {
                ProductName = "Home Appliences",
                ProductId = 3,
                Price = 5966.9m,
                Shop = new List<Shop>()
                    {
                        new Shop()
                            {
                                ShopId = 4,
                                ShopCity = "Kalmar"
                            },
                        new Shop()
                        {
                            ShopId = 1,
                            ShopCity = "Borås"
                        },
                        new Shop()
                        {
                            ShopId = 3,
                            ShopCity = "Stockholm"
                        }
                    },
                _producer = new Producer("Clas Ohlson")
            })};

        public void Run()
        {


            Console.WriteLine("Producer\tProducts");
            ProducerVsProducts();

            Console.WriteLine("Products that cost less than 50 are: ");
            PriceFilteration();

        }


        public void SortByID()
        {
            //Nareerat
            var sortedList = products.OrderBy(q => q.ProductId).ToList();


            Console.WriteLine("\nAfter sort by Id:");
            foreach (Product product in sortedList)
            {
                Console.WriteLine(product);
            }
            products = sortedList;
        }
        //Niloufar
        public void PriceFilteration()
        {
            var lessThanFifty = products.Where(s => s.Price <= 50.0M).ToList();
            foreach (var priceList in lessThanFifty)
            {
                Console.WriteLine(priceList.Price + " SEK costs one: " + priceList.ProductName);
            }
        }
        //Niloufar

        public void ProducerVsProducts()
        {
            var sortedAfterproducer =
                products.GroupBy(s => s._producer)
                    .Select(group => new
                    {
                        ProducerName = group.Key.Brand,
                        ProductCount = group.Count()
                    }
                    ).OrderBy(x => x.ProducerName);
            foreach (var group in sortedAfterproducer)
            {
                Console.WriteLine(group.ProducerName + "\t" + group.ProductCount);
            }

        }
        //Josh
        public void SearchForProductByPrice(decimal productPrice)
        {
            int count = products.Count(p => p.Price <= productPrice);
            Console.WriteLine($"Found {count} results:");

            foreach (var product in products.Where(product => product.Price <= productPrice))
            {
                Console.WriteLine(product);
            }
        }
    }
}
