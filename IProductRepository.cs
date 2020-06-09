using Laboratorium4.Models;
using System.Collections.Generic;

namespace Laboratorium4.Repositories
{
    public interface IProductRepository
    {

        public void Delete(Product product);
        public IEnumerable<Product> GetAll();
        public Product GetById(long id);
        public void Insert(Product product);
        public void Save();
    }
}