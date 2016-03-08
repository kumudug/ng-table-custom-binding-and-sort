namespace ng_table_custom.data.Context
{
    using Entities;
    using Mappings;
    using System.Data.Entity;

    public class NgTableContext : DbContext
    {
        public NgTableContext():base("NgTableContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
