using Laboratorium4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium4
{
    interface IShopRepository
    {
        public void Create();
        IEnumerable<Shop> GetAll();
        Shop GetById(long id);
        void Delete(Shop shop);
        void Insert(Shop shop);
        void Save();
    }
}
