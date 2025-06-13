using supermarket.domain.Exceptions;
using supermarket.domain.Interfaces;

namespace supermarket.domain.Entities
{
    public class Product : Entity<int>, IAggregateRoot
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? ImageURL { get; private set; }
        public decimal? Price { get; private set; }
        public decimal? Offer { get; private set; }

        public Product() :base(0){}

        // Factory method to create a new product
        public static Product Create(
            string name,
             string description,
             string imageUrl,
             decimal price,
             decimal? offer = null)
        {
            if (price <= 0)
                throw new DomainException("Price must be positive number");

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name is required");

            if (offer is < 0 or > 1)
                throw new DomainException("Offer must be 0-100%");

            return new Product
            {
                Name = name,
                Description = description,
                ImageURL = imageUrl,
                Price = price,
                Offer = offer
            };
        }
        
    }
}