using MateriaGris.Ecommerce.Domain.Entities;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Context;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Infrastructure.Persistences.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            //AsNoTraking para no bloquear tablas , trabajar asincrono
            var customers = await _applicationDbContext.Customers.AsNoTracking().ToListAsync();
            return customers;
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            var customers = await _applicationDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.CustomerId.Equals(customerId));
            return customers;
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            await _applicationDbContext.AddAsync<Customer>(customer);
            var recordsAffected = await _applicationDbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            _applicationDbContext.Update<Customer>(customer);
            var recordsAffected = await _applicationDbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            var customers = await _applicationDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.CustomerId.Equals(customerId));
            _applicationDbContext.Remove<Customer>(customers);
            var recordsAffected = await _applicationDbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
