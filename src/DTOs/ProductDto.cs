namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
        public class ProductReadDto
        {
                public Guid Id { get; set; }
                public Guid CategoryId { get; set; }
                public string? bookName { get; set; }
                public string? Description { get; set; }
                public int Stock { get; set; }
                public double Price { get; set; }
                public string? Img { get; set; }
                public string? writerName { get; set; }
        }
        public class ProductCreateDto
        {
                public Guid CategoryId { get; set; }
                public string? bookName { get; set; }
                public string? Description { get; set; }
                public int Stock { get; set; }
                public double Price { get; set; }
                public string? Img { get; set; }
                public string? writerName { get; set; }


        }
        public class ProductUpdateDto
        {

                public string? bookName { get; set; }
                public string? Description { get; set; }
                public int Stock { get; set; }
                public double Price { get; set; }
                public string? Img { get; set; }
                public string? writerName { get; set; }

        }
}
