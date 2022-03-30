using MongoDB.Driver;

namespace MongoDbAPI.Repositories {
    public class MongoDBRepository {
        
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBRepository() {
            //conexión a una colección en la nube
            client = new MongoClient("mongodb+srv://dayromartinez:5a93c754@sofka.bqmgi.mongodb.net/sofka");
            //Si no existe esta DB, la crea
            db = client.GetDatabase("inventory");
        }
        
    }
}
