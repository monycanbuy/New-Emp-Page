

using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace ServerLibrary.Data
{
    public class DataContext(DbContextOptions<DataContext> options):DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cust> Custs { get; set; }
    }
}
