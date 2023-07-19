using SearchProductCatalogue.Domain;
using SearchProductCatalogue.Domain.Events;

namespace SearchProductCatalogue.Core
{
    public class ProductAddedHandler
    {
        private readonly IProductRepository _productRepository;

        public ProductAddedHandler(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public void Handle(ProductAddedEvent productAddedEvent) 
        {
            try
            {
                _productRepository.Add(productAddedEvent.Product);
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Failed to add product {productAddedEvent.Product.Id} with error: {e}");
            }
        }
    }
}