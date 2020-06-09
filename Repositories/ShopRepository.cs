using Laboratorium4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium4.Repositories
{
    public class ShopRepository : IShopRepository
    {
        public void Create()
        {
            var shops = new List<Shop>()
            {
                new Shop() { ShopId = 0, ShopCity = "Borås" },
                new Shop() { ShopId = 1, ShopCity = "Lidköping" },
                new Shop() { ShopId = 2, ShopCity = "Göteborg" },
                new Shop() { ShopId = 3, ShopCity = "Stockholm" },
                new Shop() { ShopId = 4, ShopCity = "Kalmar" },
            };


        }


        public IEnumerable<Shop> GetAll()
        {
            throw new NotImplementedException();
        }

        public Shop GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shop shop)
        {
            throw new NotImplementedException();
        }
        public void Insert(Shop shop)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
