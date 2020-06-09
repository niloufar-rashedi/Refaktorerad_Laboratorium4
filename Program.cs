using Laboratorium4.Models;
using Laboratorium4.Repositories;
using System;
using System.Collections.Generic;

namespace Laboratorium4
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepo = new ProductRepository();

            productRepo.GetAll();

            Console.WriteLine("Find by ID");
            var myQ = productRepo.GetById(1).ProductName;
            Console.WriteLine(myQ);



            HelperClass addP = new HelperClass();
            Console.WriteLine("Remove a product by entering the name: Carpet ");
            Product removedProduct = (new Product()
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
            });
            productRepo.Delete(removedProduct);
            Console.WriteLine();



            Console.WriteLine("Insert a new product: Book ");
            Product insertedProduct = ((new Product()
            {
                ProductName = "Book",
                ProductId = 9,
                Price = 129.9m,
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
            }));
            productRepo.Insert(insertedProduct);
            foreach (Product k in addP.products)
            {
                Console.WriteLine(k.ProductName);
            }
            Console.WriteLine();


            Console.WriteLine("Search Home Appliences in the list: ");
            new SearchHelper().Run();

        }
    }
}
