using AutoMapper;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class productService : IProductService
    {
        private IProductRepository _productRepository;
        private IConfiguration _config;

        private IMapper _Mapper;
        public productService(IProductRepository productRepository, IConfiguration config, IMapper mapper)
        {
            _productRepository = productRepository;
            _config = config;
            _Mapper = mapper;
        }
        public IEnumerable<ProductReadDto> FindAll(string? searchBy, int limit, int offset)
        public IEnumerable<ProductReadDto> FindAll(string? searchBy, int limit, int offset)
        {
            IEnumerable<Product> products = _productRepository.FindAll(limit, offset);
            if (searchBy is not null)
            {
                products = products.Where(product => product.bookName.ToLower().Contains(searchBy.ToLower()));
            }
            return products.Select(_Mapper.Map<ProductReadDto>);


        }





        public ProductReadDto CreateOne(ProductCreateDto newProduct)
        {
            var product = _Mapper.Map<Product>(newProduct);
            _productRepository.CreateOne(product);
            return _Mapper.Map<ProductReadDto>(product);
        }

        public ProductReadDto UpdateOne(Guid productId, ProductUpdateDto updatedProduct)
        {
            Product? product = _productRepository.FindOne(productId);
            if (product is not null)
            {
                product.bookName = updatedProduct.bookName;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                product.Stock = updatedProduct.Stock;
                product.writerName = updatedProduct.writerName;
                _productRepository.UpdateOne(product);
                return _Mapper.Map<ProductReadDto>(product);
            }
            return null;
        }

        public bool DeleteOne(Guid productId)
        {
            Product? deleteProduct = _productRepository.FindOne(productId);
            if (deleteProduct is null) return false;
            _productRepository.DeleteOne(deleteProduct);
            return true;
        }

        public ProductReadDto? FindOne(Guid product)
        {
            var productId = _productRepository.FindOne(product);

            if (productId is not null)
            {
                var productRead = _Mapper.Map<ProductReadDto>(productId);
                return productRead;
            }
            return null;
        }
        public List<ProductReadDto> Search(string keyword)
        {

            var foundProducts = _productRepository.Search(keyword)
            .Where(product => product.bookName.Contains(keyword))
            .Select(product => new ProductReadDto
            {

                bookName = product.bookName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                writerName = product.writerName,

            })
            .ToList();
            return foundProducts;
        }
    }
}
