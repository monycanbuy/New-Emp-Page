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
    public class EmployeeRepository(DataContext _context) : IGenericRepositoryInterface<Employee>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await _context.Employees.FindAsync(id);
            if (item is null) return NotFound();

            _context.Employees.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _context.Employees
            .AsNoTracking()
            .Include(t => t.City)
            .ThenInclude(b => b.States)
            .ThenInclude(c => c.Country)
            .Include(b => b.Branch)
            .ThenInclude(d => d.Department)
            .ThenInclude(gd => gd.GeneralDepartment)
            .Include(g => g.Gender).ToListAsync();
            return employees;
        }
        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employees
                .Include(t => t.City)
                .ThenInclude(b => b.States)
                .ThenInclude(c => c.Country)
                .Include(b => b.Branch)
                .ThenInclude(d => d.Department)
                .ThenInclude(gd => gd.GeneralDepartment)
                .Include(g => g.Gender).FirstOrDefaultAsync(ei => ei.Id == id)!;
            return employee!;
        }

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (!await CheckName(item.Name!))
            {
                return new GeneralResponse(false, "Employee already added");
            }
            _context.Employees.Add(item);
            await Commit();
            return Success();
        }
        public async Task<GeneralResponse> Update(Employee employee)
        {
            var findUser = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (findUser is null) return new GeneralResponse(false, "Employee does not exist");

            findUser.Name = employee.Name;
            findUser.Address = employee.Address;
            findUser.Phone = employee.Phone;
            findUser.BranchId = employee.BranchId;
            findUser.CityId = employee.CityId;
            findUser.EmpId = employee.EmpId;
            findUser.GenderId = employee.GenderId;
            findUser.JobName = employee.JobName;
            findUser.Photo = employee.Photo;
            await _context.SaveChangesAsync();
            await Commit();
            return Success();
        }

        private async Task Commit() => await _context.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry branch not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null ? true : false;
        }

        
    }
}
