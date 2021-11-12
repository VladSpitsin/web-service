using WebService.Models;

namespace WebService.Mappers
{
    public class ProductToProductDTO : IMapper<Product, ProductDTO>
    {
        public ProductDTO Map(Product product)
        {
            if (product is null)
            {
                return null;
            }
            else
            {
                return new ProductDTO { Name = product.Name, Price = product.Price };
            }
        }
    }
}
