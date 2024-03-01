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
    public class CityRepository(DataContext _context) : IGenericRepositoryInterface<City>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.Cities.FindAsync(id);
            if (dep is null) return NotFound();

            _context.Cities.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await _context
            .Cities
            .AsNoTracking()
            .Include(c => c.States)
            .ToListAsync();
        public async Task<City> GetById(int id) => await _context.Cities.FindAsync(id);

        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "City already added");
            _context.Cities.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await _context.Cities.FindAsync(item.Id);
            if (city is null) return NotFound();
            city.Name = item.Name;
            city.StateId = item.StateId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry City not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        
    }
}
