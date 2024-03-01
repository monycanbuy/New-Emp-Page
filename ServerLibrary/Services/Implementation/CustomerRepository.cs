using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Services.Contracts;
using Shared.Entities;
using Shared.Response;

namespace ServerLibrary.Services.Implementation
{
    public class CustomerRepository(DataContext _context) : IGenericRepositoryInterface<Customer>
    {
        
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.Customers.FindAsync(id);
            if (dep is null) return NotFound();

            _context.Customers.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Customer>> GetAll() => await _context
            .Customers
            .AsNoTracking()
            .Include(p => p.PaymentType)
            .ToListAsync();
        public async Task<Customer> GetById(int id) => await _context.Customers.FindAsync(id);

        public async Task<GeneralResponse> Insert(Customer item)
        {

            _context.Customers.Add(item);
            await Commit();
            return Success();

            //var createdby = await _context.Customers.FirstOrDefaultAsync(c => c.ApplicationUsers!.Fullname == item.CreatedBy);
            //ApplicationUsers app = new ApplicationUsers();
            //if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Customer already added");

            //item.CreatedBy = createdby!.ApplicationUsers!.Fullname;

            //_context.Customers.Add(item);
            //await Commit();
            //return Success();
        }

        public async Task<GeneralResponse> Update(Customer item)
        {
            var cust = await _context.Customers.FindAsync(item.Id);
            if (cust is null)
            {
                return NotFound();
            }
            cust.Name = item.Name;
            cust.CreatedBy = item.CreatedBy;
            cust.Amount = item.Amount;
            cust.Phone = item.Phone;
            cust.PaymentTypeId = item.PaymentTypeId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry City not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        


        //private async Task<bool> CheckName(string name)
        //{
        //    var item = await _context.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        //    return item is null;
        //}
    }
}
