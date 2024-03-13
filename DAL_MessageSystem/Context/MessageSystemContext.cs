using DAL_MessageSystem.Entity;
using DAL_MessageSystem.Entity.Accounts;
using DAL_MessageSystem.Entity.Employees;
using DAL_MessageSystem.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL_MessageSystem.Context
{
    public class MessageSystemContext : DbContext
    {
        public MessageSystemContext()
        {
            Database.EnsureCreated();
        }

        public MessageSystemContext(DbContextOptions<MessageSystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=;" +
                "Initial Catalog=MessageProcessingDb;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=Yes;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Account>(acc =>
                {
                    acc.Property(ac => ac.AccountType).HasConversion(new EnumToStringConverter<AccountType>());
                    acc.Property(e => e.Id).ValueGeneratedOnAdd();
                });

            modelBuilder
                .Entity<Message>(mess =>
                {
                    mess.Property(mess => mess.State).HasConversion(new EnumToStringConverter<StateMessage>());
                    mess.Property(mess => mess.Id).ValueGeneratedOnAdd();
                    mess.HasOne(mess => mess.AccountProcessed)
                        .WithMany()
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder
               .Entity<Employee>(em =>
               {
                   em.Property(em => em.EmployeeType).HasConversion(new EnumToStringConverter<EmployeeType>());
                   em.Property(em => em.Id).ValueGeneratedOnAdd();
                   em.HasOne(em => em.Account)
                    .WithOne()
                    .HasForeignKey<Employee>(em => em.Id)
                    .OnDelete(DeleteBehavior.Cascade);
               });

            modelBuilder
               .Entity<Report>(rp =>
               {
                   rp.Property(rp => rp.Id).ValueGeneratedOnAdd();
                   rp.HasOne(rp => rp.AccountCreated)
                    .WithMany()
                    .OnDelete(DeleteBehavior.SetNull);

                   rp.HasMany<Message>(rp => rp.MessagesList)
                   .WithOne()
                   .OnDelete(DeleteBehavior.SetNull);
               });
        }
    }
}
