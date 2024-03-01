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
    public class CountryRepository(DataContext _context) : IGenericRepositoryInterface<Country>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.Countries.FindAsync(id);
            if (dep is null) return NotFound();

            _context.Countries.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await _context.Countries.ToListAsync();
        public async Task<Country> GetById(int id) => await _context.Countries.FindAsync(id);

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Country already added");
            _context.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var dep = await _context.Countries.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry Country not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        
    }
}
