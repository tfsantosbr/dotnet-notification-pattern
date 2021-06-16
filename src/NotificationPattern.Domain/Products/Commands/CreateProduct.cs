namespace NotificationPattern.Domain.Products.Commands
{
    public class CreateProduct
    {
        public string EAN { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}