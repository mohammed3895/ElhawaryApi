namespace ElhawaryApi.Data
{
    public class AppDbcontext(DbContextOptions<AppDbcontext> opts) : DbContext(opts)
    {
        public DbSet<Maintenance> MaintenanceDepartment { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Technicans> Technicans { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MaintenanceStatus> MaintenanceStatus { get; set; }
        public DbSet<MaintenanceStatusType> MaintenanceStatusTypes { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<AccessoryType> AccessoryTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Technicans>
                (
                    t => t.HasOne<Department>(m => m.Department).WithMany(d => d.Technicans)
                );



            // DB SEED DATA
            modelBuilder.Entity<MaintenanceType>().HasData
                (
                    new MaintenanceType { Id = 1, Type = 0 },
                    new MaintenanceType { Id = 2, Type = 1 }
                );

            modelBuilder.Entity<MaintenanceStatusType>().HasData
                (
                    new MaintenanceStatusType { Id = 1, TypeName = "InProgress" },
                    new MaintenanceStatusType { Id = 2, TypeName = "Done" },
                    new MaintenanceStatusType { Id = 3, TypeName = "Refused" }
                );

            modelBuilder.Entity<AccessoryType>().HasData
                (
                    new AccessoryType { Id = 1, Name = "Battery" },
                    new AccessoryType { Id = 2, Name = "Cover" },
                    new AccessoryType { Id = 3, Name = "Screen Protector" },
                    new AccessoryType { Id = 4, Name = "Data Transfer Kit" },
                    new AccessoryType { Id = 5, Name = "Charge" },
                    new AccessoryType { Id = 6, Name = "Other" }
                );
        }
    }
}
