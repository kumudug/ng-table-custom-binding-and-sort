namespace ng_table_custom.data.Entities
{
    using System;

    public abstract class EntityBase : IEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
