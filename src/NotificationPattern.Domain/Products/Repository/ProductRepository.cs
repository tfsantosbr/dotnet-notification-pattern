using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationPattern.Domain.Products.Repository
{
    public class ProductRepository
    {
        private static readonly List<Product> _products = new();

        public bool AnyProductByEan(string ean)
        {
            return _products.Any(p => p.EAN == ean);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product GetById(Guid id)
        {
            return _products.FirstOrDefault(u => u.Id == id);
        }

        internal void Update(Product product)
        {
            var currentProduct = GetById(product.Id);

            if (currentProduct != null) currentProduct = product;
        }

        public IEnumerable<Product> ListProducts()
        {
            return _products;
        }
    }
}