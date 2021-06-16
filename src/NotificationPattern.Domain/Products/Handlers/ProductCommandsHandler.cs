using System;
using NotificationPattern.Domain.Products.Commands;
using NotificationPattern.Domain.Products.Repository;

namespace NotificationPattern.Domain.Products.Handlers
{
    public class ProductCommandsHandler
    {
        private readonly ProductRepository _productRepository;

        public ProductCommandsHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Handle(CreateProduct request)
        {
            // TODO: Verifica se a requisição é válida

            // Cria o produto
            var product = new Product(
                ean: request.EAN,
                name: request.Name,
                price: request.Price,
                stock: request.Stock
            );

            // TODO: Verifica se o EAN informado já não está cadastrado
            // substituir a exception por uma notificação
            // if (_productRepository.AnyProductByEan(product.EAN))
            // {
            //     throw new Exception("Já existe um produto com este EAN");
            // }

            // Adiciona o produto no repositório
            _productRepository.Add(product);

            // Retorna o produto
            return product;
        }

        public void Handle(UpdateProduct request)
        {
            // TODO: Verifica se a requisição é válida
            
            // Retorna o produto
            var product = _productRepository.GetById(request.Id);

            // Gera uma exception se o produto não for encontrado
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            // Atualiza o produto
            product.Update(
                name: request.Name,
                price: request.Price,
                stock: request.Stock
                );

            // Atualiza o produto no repositório
            _productRepository.Update(product);
        }
    }
}