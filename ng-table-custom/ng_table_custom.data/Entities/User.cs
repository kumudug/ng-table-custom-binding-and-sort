namespace ng_table_custom.data.Entities
{
    using System;

    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}
