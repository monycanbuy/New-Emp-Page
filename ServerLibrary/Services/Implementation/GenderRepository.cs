using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Services.Contracts;
using Shared.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Services.Implementation
{
    public class GenderRepository(DataContext _context) : IGenericRepositoryInterface<Gender>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.Genders.FindAsync(id);
            if (dep is null) return NotFound();

            _context.Genders.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Gender>> GetAll() => await _context
            .Genders
            .ToListAsync();
        public async Task<Gender> GetById(int id) => await _context.Genders.FindAsync(id);

        public async Task<GeneralResponse> Insert(Gender item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
                return new GeneralResponse(false, "Gender already added");
            _context.Genders.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Gender item)
        {
            var dep = await _context.Genders.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry gender not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await _context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.Genders.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        
    }
}
