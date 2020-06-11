using Laboratorium4.Models;
using Laboratorium4.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium4
{
    public class RunTheApp
    {
        public void Run()
        {
            IProductRepository productRepoInterface = new ProductRepository();

            //Parul 
            while (true)
            {
                Console.WriteLine("\n Please see options below:");
               //JsonManager a = new JsonManager();
                Console.WriteLine("0.Exit\n1. Product Add\n2. Product Delete\n3. Store Add\n4. Store Delete\n5. To search All or part of the product name.\n6. Products that cost less than the specified price, show a maximum of 10 products.\n7. To show a list of all manufacturers\n8. how many products each manufacturer has ");
                Console.Write("\nSelect an option ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                    return;
                
                ProductRepository pRepo = new ProductRepository();
                switch (choice)
                {
                    case 1:
                        //insert product in list
                        productRepoInterface.Insert(new Product { });
                        break;

                    case 2:
                        //delete product
                       //productRepoInterface.Remove();
                        // FileProductRepository.Delete(Product);
                        break;

                    case 3:

                        //Add store
                        //productRepoInterface.Add(Stores);
                        break;
                    case 4:
                        //delete store
                        // productRepoInterface.Delete(Stores);
                        break;

                    case 5:
                        //Calling one of Search methods


                        break;

                    case 6:
                        // Product that cost less than specified price
                        new HelperClass().PriceFilteration();
                        new HelperClass().SearchForProductByPrice(50.0M);
                        break;

                    case 7:
                        //to show a list of all manufacturers 
                        new HelperClass().ProducerVsProducts();
                            
                            break;



                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

            }
        }
    }
}
