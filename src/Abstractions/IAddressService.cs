namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers

{
 public interface IAddressService
{
    public IEnumerable<AddressReadDto> FindAll();
    public AddressReadDto? FindOne(Guid id);
    public AddressReadDto CreateOne(AddressCreateDto address, string userId);
    public AddressReadDto? UpdateOne(Guid id, Address address);
    public bool DeleteOne(Guid id);
}
}