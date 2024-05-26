using Microsoft.EntityFrameworkCore;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    [Index(nameof(CategoryName), IsUnique = true)]
    public class Category
    {

        public Guid Id { get; set; }
        public IEnumerable<Product> product { get; set; }
        public string CategoryName { get; set; }

    }
}