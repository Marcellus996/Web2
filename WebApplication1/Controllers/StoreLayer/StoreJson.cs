using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Controllers.StoreLayer
{
    public class StoreJson : Store
    {
        private string path;

        public StoreJson(string path)
        {
            this.path = path;
        }

        public void Close()
        {
        }

        public void Create(Product product)
        {
            var products = GetAll();
            var ids = new HashSet<int>();
            var newId = 0;

            for (var i = 0; i < products.Count; i++) ids.Add(products[i].Id);
            for (var i = 0; i < ids.Count + 1; i++)
            {
                if (!ids.Contains(i)) {
                    newId = i;
                    break;
                }
            }

            product.Id = newId;
            products.Add(product);

            writeAll(products);
        }

        public void Delete(Product product)
        {
            var products = GetAll();
            var newProducts = new List<Product>();

            for (var i = 0; i < products.Count; i++)
            {
                if (products[i].Id.Equals(product.Id))
                {
                    continue;
                }
                newProducts.Add(products[i]);
            }

            writeAll(newProducts);
        }

        public List<Product> GetAll()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }

        public Product GetById(int id)
        {
            var products = GetAll();
            for (var i = 0; i < products.Count; i++)
            {
                if (products[i].Id.Equals(id))
                {
                    return products[i];
                }
            }
            throw new KeyNotFoundException();
        }

        public void Update(Product product)
        {
            var products = GetAll();
            var newProducts = new List<Product>();

            for (var i = 0; i < products.Count; i++)
            {
                if (products[i].Id.Equals(product.Id))
                {
                    continue;
                }
                newProducts.Add(products[i]);
            }
            newProducts.Add(product);

            writeAll(newProducts);
        }

        private void writeAll(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products);
            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(json);
            }
        }
    }
}