using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories {
    //Servicios de este CRUD
    public interface IProductCollection {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);
    }
}
