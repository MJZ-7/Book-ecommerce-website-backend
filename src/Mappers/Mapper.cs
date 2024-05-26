using AutoMapper;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class Mapper : Profile
    {

        public Mapper()
        {
            //User mapper
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<UserReadDto, UserUpdateDto>();
            CreateMap<UserUpdateDto, UserReadDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserCreateDto>();
            CreateMap<UserCreateDto, User>();

            //Product mapper
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductReadDto, Product>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductReadDto>();


            // Order mapper

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderReadDto, Order>();


            //category mapper
            CreateMap<CategoryReadDto, Category>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryReadDto, Category>();

            CreateMap<AddressReadDto, Address>();
            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressCreateDto, Address>();
        }
    }
}