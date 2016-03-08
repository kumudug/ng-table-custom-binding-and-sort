namespace ng_table_custom.data.Mappings
{
    using Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : class, IEntity
    {
        public BaseMap()
        {
            #region Primary key
            this.HasKey(t => t.Id);
            #endregion

            #region Mappings
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.RowVersion).IsRowVersion();
            #endregion
        }
    }
}
