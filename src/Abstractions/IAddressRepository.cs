namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers

{
public interface IAddressRepository
{
    public IEnumerable<Address> FindAll();
    public Address? FindOne(Guid id);
    public Address CreateOne(Address address);
    public Address? UpdateOne(Address updatedAddress);
    public bool DeleteOne(Guid id);
}
}