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
            po.Remove(product);
            Save();
        }

        public void Insert(Product product)
        {
            po.Add(product);
            Save();
        }

        public void Save()
        {
            new HelperClass().Run();
        }

    }

}