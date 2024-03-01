using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Services.Contracts;
using Shared.Entities;
using Shared.Response;

namespace ServerLibrary.Services.Implementation
{
    public class PaymentTypeRepository(DataContext _context) : IGenericRepositoryInterface<PaymentType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.PaymentTypes.FindAsync(id);
            if (dep is null) return NotFound();

            _context.PaymentTypes.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<PaymentType>> GetAll() => await _context
            .PaymentTypes
            .AsNoTracking()
            .ToListAsync();
        public async Task<PaymentType> GetById(int id) => await _context.PaymentTypes.FindAsync(id);

        public async Task<GeneralResponse> Insert(PaymentType item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Payment Type already added");
            _context.PaymentTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(PaymentType item)
        {
            var ptype = await _context.PaymentTypes.FindAsync(item.Id);
            if (ptype is null) return NotFound();
            ptype.Name = item.Name;
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry Payment not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.PaymentTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

       
    }
}
