namespace ng_table_custom.data.Repository
{
    using Context;
    using ng_table_custom.data.Entities;

    public class UserRepository : BaseRepository<User, NgTableContext>, IUserRepository
    {
        private readonly NgTableContext _context;

        public UserRepository(NgTableContext context):base(context)
        {
            _context = context;
        }
    }
}
