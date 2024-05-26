using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class ProductRepository : IProductRepository
    {
        private DbSet<Product> _products;

        private DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _products = databaseContext.Product;
            _dbContext = databaseContext;
        }
        public IEnumerable<Product> FindAll(int limit, int offset)
        {
            if (limit == 0 & offset == 0)
            {
                return _products;
            }
            return _products.Skip(offset).Take(limit);
        }

        public Product? FindOne(Guid productId)
        {
            return _dbContext.Product.Find(productId);
        }


        public Product CreateOne(Product product)
        {
            _products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product UpdateOne(Product updatedProduct)
        {
            _dbContext.Product.Update(updatedProduct);
            _dbContext.SaveChanges();
            return updatedProduct;
        }
        public bool DeleteOne(Product product)
        {
            _dbContext.Product.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<Product> Search(string keyword)
        {
            return _dbContext.Product
                    .Where(p => p.bookName.Contains(keyword))
                    .ToList();
        }

    }


}
