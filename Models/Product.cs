using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium4.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public IList<Shop> Shop { get; internal set; }
        public Producer _producer;
        public IEnumerable<Product> products;
        public void RemoveShop(Shop shop)
        {
            Shop.Remove(shop);
        }

    }
}
