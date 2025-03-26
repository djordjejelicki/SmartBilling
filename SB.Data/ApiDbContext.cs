using Microsoft.EntityFrameworkCore;
using SB.Models;

namespace SB.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = new Guid("113e7663-2cac-45c6-b349-b6189d9c3f4d"), Name = "Bicycle",   Description = "Modern bycycle for ride", Price = 250 },
                new Product { Id = new Guid("1a24b23a-4e82-4413-af4d-fcd45aecb01a"), Name = "Desk",      Description = "Working desk",            Price = 190 },
                new Product { Id = new Guid("21bbe837-b363-46c0-b3ad-41a5d4b7758a"), Name = "Chair",     Description = "Office chair",            Price = 120 },
                new Product { Id = new Guid("7d3c4e45-6103-4271-8438-a445220137e3"), Name = "Iphone 14", Description = "Apple smart phone",       Price = 750 },
                new Product { Id = new Guid("aefcc042-ece1-472c-96be-26211771a5e5"), Name = "Lamp",      Description = "Modern House Lamp",       Price = 60  }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = new Guid("f3b1d4a8-7c2d-4f84-81df-2a5e3b671e1b") },
                new Customer { Id = new Guid("c7e04f65-3b97-4b11-99b8-09d56dc8d25a") },
                new Customer { Id = new Guid("a5d8f1ea-66b9-4f4e-bc9b-8f6395f5d2f2") },
                new Customer { Id = new Guid("e3f4a9b2-2d78-4db8-8bfc-cd08c2a7a9f3") },
                new Customer { Id = new Guid("6b29fc40-68a2-4b80-91b4-914a5f2b7f04") }
            );

            modelBuilder.Entity<EmployeeRoles>().HasKey(u => new { u.EmployeeId, u.RoleId });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945"), Name = "Djordje" , Surname = "Jelicki"   },
                new Employee { Id = new Guid("9ec8a24f-2002-482c-8d8a-12487a87ac6f"), Name = "Igor",     Surname = "Skrofanov" },
                new Employee { Id = new Guid("fc8d4d36-6d32-4455-81ce-bca99786d515"), Name = "Matija",   Surname = "Vrebalov"  },
                new Employee { Id = new Guid("2b0bcf24-e190-403c-af44-c47cd4a9171d"), Name = "Stanimir", Surname = "Blazin"    },
                new Employee { Id = new Guid("bbe98bab-c759-446b-a16c-39442e9a0e88"), Name = "Luka",     Surname = "Miladinovc"}
                
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449"), RoleName = "Cash register officer" },
                new Role { Id = new Guid("6305cb2f-0746-4bbb-90c5-d60c2f88da6f"), RoleName = "Security officer"      },
                new Role { Id = new Guid("2fa92b0d-9373-48e7-a28a-21af57c4b681"), RoleName = "Cash register manager" },
                new Role { Id = new Guid("aff40a81-7209-40ed-a5a2-15eb57acd250"), RoleName = "Exchange officer"      }
            );

            modelBuilder.Entity<EmployeeRoles>().HasData(
                new EmployeeRoles { EmployeeId = new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945"), RoleId = new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449") },
                new EmployeeRoles { EmployeeId = new Guid("9ec8a24f-2002-482c-8d8a-12487a87ac6f"), RoleId = new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449") },
                new EmployeeRoles { EmployeeId = new Guid("fc8d4d36-6d32-4455-81ce-bca99786d515"), RoleId = new Guid("6305cb2f-0746-4bbb-90c5-d60c2f88da6f") },
                new EmployeeRoles { EmployeeId = new Guid("2b0bcf24-e190-403c-af44-c47cd4a9171d"), RoleId = new Guid("2fa92b0d-9373-48e7-a28a-21af57c4b681") },
                new EmployeeRoles { EmployeeId = new Guid("bbe98bab-c759-446b-a16c-39442e9a0e88"), RoleId = new Guid("aff40a81-7209-40ed-a5a2-15eb57acd250") }

            );
        }

    }
}
