using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        // Get product by id
        Task<Product> GetProductByIdAsync(int id);

        // Get List Product
        Task<IReadOnlyList<Product>> GetProductsAsync();

        // Get List Product
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        // Get List Product
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}