using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Controllers.StoreLayer
{
    public class StoreJsonSafe : Store
    {
        private Store realStore;

        public StoreJsonSafe(Store realStore)
        {
            this.realStore = realStore;
        }

        private object _lock = new object();


        public void Close()
        {
            lock (_lock)
            {
                realStore.Close();
            }
        }

        public void Create(Product product)
        {
            lock (_lock)
            {
                realStore.Create(product);
            }
        }

        public void Delete(Product product)
        {
            lock (_lock)
            {
                realStore.Delete(product);
            }
        }

        public List<Product> GetAll()
        {
            lock (_lock)
            {
                return realStore.GetAll();
            }
        }

        public Product GetById(int id)
        {
            lock (_lock)
            {
                return realStore.GetById(id);
            }
        }

        public void Update(Product product)
        {
            lock (_lock)
            {
                realStore.Update(product);
            }
        }
    }
}