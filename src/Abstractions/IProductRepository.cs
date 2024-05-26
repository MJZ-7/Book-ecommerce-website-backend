namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IProductRepository
    {

        public IEnumerable<Product> FindAll(int limit, int offset);
        public Product? FindOne(Guid productId);

        public Product CreateOne(Product product);

        public Product UpdateOne(Product updatedProduct);

        public bool DeleteOne(Product product);

        public IEnumerable<Product> Search(string keyword);
        public void UpdateStock(Product updatedProduct);
    }
}