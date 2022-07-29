namespace DataAccess.Entities
{
    using Microsoft.EntityFrameworkCore;
    //using System.Data.Entity;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<Infrastructure>()
            //    .HasOne(i => i.State)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Client>()
                .HasOne(c => c.State)
                .WithMany()                
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.NoAction);

            //    .HasMany(i => i.Clients)
            //    .
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);

            //modelBuilder
            //    .Entity<Client>()
            //    .HasMany(c => c.Infrastructures)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);


            //base.OnModelCreating(modelBuilder);

            //.HasMany(i => i.Clients)
            //.WithMany(c => c.Infrastructures)
            //.WillCascadeOnDelete(false);
            //.WithOptional()
            //.WillCascadeOnDelete(false)
            //        .WithMany(c => c.Infrastructures)
            //        .
            //;
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<Infrastructure> Infrastructure { get; set; }

        public DbSet<InfrastructureVariable> InfrastructureVariables { get; set; }
        
        public DbSet<Instance> Instance { get; set; }

        public DbSet<TypeInfrastructure> TypeInfrastructure { get; set; }

        public DbSet<TypeInstance> TypeInstance { get; set; }

        public DbSet<Configuration> Configuration { get; set; }

        public DbSet<APIConstant> APIConstant { get; set; }
    }
}
