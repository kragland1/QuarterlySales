using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        { }

        public DbSet<Sales> Sales { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    Firstname = "Billy Bob",
                    Lastname = "Jonah",
                    DOB = new DateTime(1977, 11, 15),
                    DateOfHire = new DateTime(1996, 12, 1),
                    ManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 3,
                    Firstname = "Chris",
                    Lastname = "Storm",
                    DOB = new DateTime(1988, 1, 15),
                    DateOfHire = new DateTime(2006, 10, 1),
                    ManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 2,
                    Firstname = "David",
                    Lastname = "Ferrari",
                    DOB = new DateTime(1989, 4, 11),
                    DateOfHire = new DateTime(2010, 3, 10),
                    ManagerId = 1
                },
                new Employee
                {
                    EmployeeId = 4,
                    Firstname = "Billy Bob",
                    Lastname = "Jonah",
                    DOB = new DateTime(1977, 11, 15),
                    DateOfHire = new DateTime(1996, 12, 1),
                    ManagerId = 9
                },
                new Employee
                {
                    EmployeeId = 5,
                    Firstname = "Carter",
                    Lastname = "Hans",
                    DOB = new DateTime(1994, 9, 11),
                    DateOfHire = new DateTime(2016, 7, 22),
                    ManagerId = 0
                }
                );
            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 3,
                    Year = 2001,
                    Amount = 20,
                    EmployeeId = 1

                },
                new Sales
                {
                    SalesId = 2,
                    Quarter = 3,
                    Year = 2011,
                    Amount = 500,
                    EmployeeId = 3
                },
                new Sales
                {
                    SalesId = 3,
                    Quarter = 3,
                    Year = 2012,
                    Amount = 200,
                    EmployeeId = 4
                },
                new Sales
                {
                    SalesId = 4,
                    Quarter = 3,
                    Year = 2006,
                    Amount = 400,
                    EmployeeId = 2
                },
                new Sales
                {
                    SalesId = 5,
                    Quarter = 4,
                    Year = 2012,
                    Amount = 300,
                    EmployeeId = 5
                }
                );
        }

    }
}
