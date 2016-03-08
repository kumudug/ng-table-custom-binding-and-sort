namespace ng_table_custom.data.Repository
{
    using ng_table_custom.data.Entities;
    using System.Data.Entity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaseRepository<ET, CT> : IBaseRepository<ET>
        where ET : class, IEntity
        where CT : DbContext
    {
        private readonly CT _context;

        public BaseRepository(CT context)
        {
            _context = context;
        }

        #region IBaseRepository members

        public IQueryable<ET> NotTracking
        {
            get { return _context.Set<ET>().AsNoTracking<ET>(); }
        }

        public IQueryable<ET> QueryAll
        {
            get { return _context.Set<ET>().AsQueryable<ET>(); }
        }

        public async Task<bool> Delete(int Id)
        {
            var element = await FindById(Id);
            return await Delete(element);
        }

        public async Task<bool> Delete(ET entity)
        {
            _context.Set<ET>().Attach(entity);
            _context.Set<ET>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ET> FindById(int Id)
        {
            //return await _context.Set<ET>().FindAsync(Id);
            //Moq support is not implemented for FindAsync
            return await _context.Set<ET>().Where(a => a.Id == Id).SingleOrDefaultAsync();
        }

        public IQueryable<ET> FindByPredicate(string predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(ET entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertOrUpdate(ET entity)
        {
            _context.Entry<ET>(entity).State = entity.Id == -1 ? EntityState.Added : EntityState.Modified;
            if (entity.Id != -1)
            {
                _context.Entry<ET>(entity).Property(o => o.CreatedBy).IsModified = false;
                _context.Entry<ET>(entity).Property(o => o.CreatedDate).IsModified = false;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(ET entity)
        {
            _context.Entry<ET>(entity).State = EntityState.Modified;
            _context.Entry<ET>(entity).Property(o => o.CreatedBy).IsModified = false;
            _context.Entry<ET>(entity).Property(o => o.CreatedDate).IsModified = false;
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
