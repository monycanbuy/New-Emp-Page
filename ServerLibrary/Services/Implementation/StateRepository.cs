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
    public class StateRepository(DataContext _context) : IGenericRepositoryInterface<State>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.States.FindAsync(id);
            if (dep is null)
            {
                return NotFound();
            }

            _context.States.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<State>> GetAll() => await _context
            .States
            .AsNoTracking()
            .Include(c => c.Country)
            .ToListAsync();
        public async Task<State> GetById(int id) => await _context.States.FindAsync(id);

        public async Task<GeneralResponse> Insert(State item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "State already added");
            _context.States.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(State item)
        {
            var dep = await _context.States.FindAsync(item.Id);
            if (dep is null)
            {
                return NotFound();
            }
            dep.Name = item.Name;
            dep.CountryId = item.CountryId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry state not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.States.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        
    }
}
