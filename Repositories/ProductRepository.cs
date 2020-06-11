using Laboratorium4.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Laboratorium4.Repositories
{
    public class ProductRepository : IProductRepository
    {
        List<Product> po = (List<Product>)new HelperClass().products;

        // List<Product> products;
        public ProductRepository()
        {
            new HelperClass().Run();   
        }

        public IEnumerable<Product> GetAll()
        {
            return po;
        }

        public Product GetById(long id)
        {
            return po.First(p => p.ProductId == id);
        }

        public void Delete(Product product)
        {
            //Josh
            var toBeDeleted = po.Find(m => m.ProductName.Contains(product.ProductName));
            po.Remove(toBeDeleted);
            Save();
        }

        public void Insert(Product product)
        {

            //Josh's version of Insert():
                    //public void Insert(string name, decimal price, Manufacturer manufacturer)
                    //{
                    //    var product = new Product(name, price, manufacturer);
                    //    ProductList.Add(product);
                    //}
            //I do not know if three parameters passed to the method are OK; This methos was supposed to take
            //Product type of product... Though it can be good to use. 

            po.Add(product);
            Save();
        }

        public void Save()
        {
            new HelperClass().Run();
        }

    }

}