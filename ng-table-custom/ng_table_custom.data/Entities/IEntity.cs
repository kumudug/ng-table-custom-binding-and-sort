namespace ng_table_custom.data.Entities
{
    using System;

    public interface IEntity
    {
        int Id { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        byte[] RowVersion { get; set; }
    }
}
