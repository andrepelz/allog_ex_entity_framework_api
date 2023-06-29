using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public class CustomerRepository : ICustomerRepository {
    private readonly CustomerContext _context;
    private readonly IMapper _mapper;

    public CustomerRepository(CustomerContext context, IMapper mapper) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    

    public async Task<IEnumerable <Customer>> GetCustomersAsync() {
        return await _context.Customers
            .OrderBy(c => c.CustomerId)
            .ToListAsync();
    }

    public async Task<IEnumerable <Customer>> GetCustomersWithAddressesAsync() {
        return await _context.Customers
            .OrderBy(c => c.CustomerId)
            .Include(c => c.Addresses)
            .ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int customerId) {
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task<Customer?> GetCustomerWithAddressesByIdAsync(int customerId) {
        return await _context.Customers
            .Include(c => c.Addresses)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task<Customer?> GetCustomerByCpfAsync(string cpf) {
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public void AddCustomer(Customer customer) {
        _context.Customers.Add(customer);
    }

    public void UpdateCustomer(Customer customer, CustomerForUpdateDto customerForUpdateDto) {
        _mapper.Map(customerForUpdateDto, customer);
    }

    public void RemoveCustomer(Customer customer) {
        _context.Customers.Remove(customer);
    }

    public void PatchCustomer(Customer customer, CustomerForPatchDto customerForPatchDto) {
        _mapper.Map(customerForPatchDto, customer);
    }



    public async Task<IEnumerable <Address>?> GetAddressesAsync(int customerId) {
        var customerFromDatabase = await GetCustomerWithAddressesByIdAsync(customerId);
        return customerFromDatabase?.Addresses;
    }

    public async Task<Address?> GetAddressByIdAsync(int customerId, int addressId) {
        var customerFromDatabase = await GetCustomerWithAddressesByIdAsync(customerId);
        var addressFromDatabase = customerFromDatabase
            ?.Addresses
            .FirstOrDefault(a => a.AddressId == addressId);

        return addressFromDatabase;
    }

    public void AddAddress(Customer customer, Address address) {
        customer.Addresses.Add(address);
    }

    public void UpdateAddress(Address address, AddressForUpdateDto addressForUpdateDto) {
        _mapper.Map(addressForUpdateDto, address);
    }

    public void RemoveAddress(Address address) {
        _context.Remove(address);
    }

    public void PatchAddress(Address address, AddressForPatchDto addressForPatchDto) {
        _mapper.Map(addressForPatchDto, address);
    }

    

    public async Task<bool> SaveChangesAsync() {
        return await _context.SaveChangesAsync() > 0;
    }
}
