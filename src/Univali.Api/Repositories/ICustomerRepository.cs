using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public interface ICustomerRepository {
    // CUSTOMER GET
    Task<IEnumerable <Customer>> GetCustomersAsync();
    Task<IEnumerable <Customer>> GetCustomersWithAddressesAsync();
    Task<Customer?> GetCustomerByIdAsync(int customerId); 
    Task<Customer?> GetCustomerWithAddressesByIdAsync(int customerId);
    Task<Customer?> GetCustomerByCpfAsync(string cpf);
    // CUSTOMER POST
    void AddCustomer(Customer customer);
    // CUSTOMER PUT
    void UpdateCustomer(Customer customer, CustomerForUpdateDto customerForUpdateDto);
    // CUSTOMER DELETE
    void RemoveCustomer(Customer customer);
    // CUSTOMER PATCH
    void PatchCustomer(Customer customer, CustomerForPatchDto customerForPatchDto);


    // ADDRESS GET
    Task<IEnumerable <Address>?> GetAddressesAsync(int customerId);
    Task<Address?> GetAddressByIdAsync(int customerId, int addressId);
    // ADDRESS POST
    void AddAddress(Customer customer, Address address);
    // ADDRESS PUT
    void UpdateAddress(Address address, AddressForUpdateDto addressForUpdateDto);
    // CUSTOMER DELETE
    void RemoveAddress(Address address);
    // CUSTOMER PATCH
    void PatchAddress(Address address, AddressForPatchDto addressForPatchDto);


    // CONTEXT COMMIT
    Task<bool> SaveChangesAsync();
}