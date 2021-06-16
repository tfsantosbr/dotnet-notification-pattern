using System;

namespace NotificationPattern.Domain.Products
{
    // Regras de negócio do PRODUTO
    // - Nome do Produto é obrigatório
    // - EAN é obrigatório
    // - Preço deve ser maior que zero
    // - Estoque deve ser maior que zero

    public class Product
    {
        public Product(string ean, string name, decimal price, int stock, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            EAN = ean;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Guid Id { get; private set; }
        public string EAN { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public void Update(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}