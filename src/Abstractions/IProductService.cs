namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IProductService
    {
        public IEnumerable<ProductReadDto> FindAll(string? searchBy, int limit, int offset);
        public ProductReadDto? FindOne(Guid product);
        public ProductReadDto CreateOne(ProductCreateDto product);
        public ProductReadDto UpdateOne(Guid productId, ProductUpdateDto product);
        public bool DeleteOne(Guid product);
        public List<ProductReadDto> Search(string keyword);
    }
}