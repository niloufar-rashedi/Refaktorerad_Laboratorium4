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

            var path = GetUserHomePath();
            var programPath = Path.Combine(path, "Lab4");
            var jsonPath = Path.Combine(programPath, "Products.json");

            SaveToJson(jsonPath, products);

            var records = LoadFromJson<Product>(jsonPath);

                foreach (var p in records)
                {
                    Console.WriteLine(p.ProductName);
                }


            Console.WriteLine("Producer\tProducts");
            ProducerVsProducts();

            Console.WriteLine("Products that cost less than 50 are: ");
            PriceFilteration();

        }


        public void SortByID()
        {
            var query = products.OrderBy(c => c.ProductId);

            Console.WriteLine("Products sorted by their ID are: ");
            foreach (var p in query)
            {
                Console.WriteLine(p.ProductId);
            }
        }
        public void PriceFilteration()
        {
            var lessThanFifty = products.Where(s => s.Price <= 50.0M).ToList();
            foreach (var priceList in lessThanFifty)
            {
                Console.WriteLine(priceList.Price + " SEK costs one: " + priceList.ProductName);
            }
        }

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
        public string GetUserHomePath()
        {
            return
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
                    Environment.SpecialFolderOption.DoNotVerify);
        }

        public IEnumerable<T> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var records = System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonString);
            return records;
        }

        public void SaveToJson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }
    }
}
