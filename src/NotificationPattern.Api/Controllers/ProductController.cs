using System;
using Microsoft.AspNetCore.Mvc;
using NotificationPattern.Domain.Products.Commands;
using NotificationPattern.Domain.Products.Handlers;
using NotificationPattern.Domain.Products.Repository;

namespace NotificationPattern.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductCommandsHandler _handler;
        private readonly ProductRepository _userRepository;

        public ProductController(ProductCommandsHandler handler, ProductRepository userRepository)
        {
            _handler = handler;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProduct request)
        {
            var product = _handler.Handle(request);

            return Created($"products/{product.Id}", product);
        }

        [HttpPut("{productId}")]
        public IActionResult CreateProduct(Guid productId, UpdateProduct request)
        {
            _handler.Handle(request);

            return NoContent();
        }
    }
}
