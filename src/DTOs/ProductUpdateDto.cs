namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class ProductUpdateDto
    {
        public ProductSize size { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public double Price { get; set; }

        public string? Color { get; set; }


    }
}