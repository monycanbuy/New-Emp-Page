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
    public class DepartmentRepository(DataContext _context) : IGenericRepositoryInterface<Department>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _context.Departments.FindAsync(id);
            if (dep is null) return NotFound();

            _context.Departments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await _context
            .Departments.AsNoTracking()
            .Include(gd => gd.GeneralDepartment)
            .ToListAsync();
        public async Task<Department> GetById(int id) => await _context.Departments.FindAsync(id);

        public async Task<GeneralResponse> Insert(Department item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            _context.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var dep = await _context.Departments.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            dep.GeneralDepartmentId = item.GeneralDepartmentId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry department not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        
    }
}
