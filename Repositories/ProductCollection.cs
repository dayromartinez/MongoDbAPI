using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories {
    public class ProductCollection : IProductCollection {

        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Product> Collection;

        public ProductCollection() {
            //Si no existe, este comando crea la colección
            Collection = _repository.db.GetCollection<Product>("products");
        }

        public async Task<List<Product>> GetAllProducts() {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetProductById(string id) {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }

        public async Task InsertProduct(Product product) {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product) {
            var filter = Builders<Product>.Filter
                .Eq(producto => producto.Id, product.Id);

            await Collection.ReplaceOneAsync(filter, product);
        }

        public async Task DeleteProduct(string id) {
            //El comando Eq() hace referencia a un "Equals()"
            var filter = Builders<Product>.Filter.Eq(product => product.Id, id);
            await Collection.DeleteOneAsync(filter);
        }
    }
}
