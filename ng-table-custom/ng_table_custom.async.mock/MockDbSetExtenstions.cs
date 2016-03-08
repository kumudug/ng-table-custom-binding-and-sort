namespace ng_table_custom.async.mock
{
    using Moq;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public static class MockDbSetExtenstions
    {
        public static Mock<DbSet<TEntity>> SetupLinq<TEntity>(this Mock<DbSet<TEntity>> set, IQueryable<TEntity> data)
            where TEntity : class
        {
            // Enable direct async enumeration of set
            set.As<IDbAsyncEnumerable<TEntity>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(() => new TestDbAsyncEnumerator<TEntity>(data.GetEnumerator()));

            // Enable LINQ queries with async enumeration
            set.As<IQueryable<TEntity>>()
                .Setup(m => m.Provider)
                .Returns(() => new TestDbAsyncQueryProvider<TEntity>(data.Provider));

            // Wire up LINQ provider to fall back to in memory LINQ provider of the data
            set.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(() => data.Expression);
            set.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(() => data.ElementType);
            set.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            // Enable Include directly on the DbSet (Include extension method on IQueryable is a no-op when it's not a DbSet/DbQuery)
            // Include(string) and Include(Func<TEntity, TProperty) both fall back to string
            set.Setup(s => s.Include(It.IsAny<string>())).Returns(set.Object);
            return set;
        }

        public static Mock<DbSet<TEntity>> SetupFind<TEntity>(this Mock<DbSet<TEntity>> set, Func<object[], TEntity, bool> finder)
            where TEntity : class
        {
            set.Setup(s => s.Find(It.IsAny<object[]>()))
                .Returns((object[] keyValues) => set.Object.SingleOrDefault(e => finder(keyValues, e)));

            return set;
        }

        public static Mock<DbSet<TEntity>> SetupAddAndRemove<TEntity>(this Mock<DbSet<TEntity>> set, IQueryable<TEntity> data)
            where TEntity : class
        {
            set.Setup(s => s.Add(It.IsAny<TEntity>()))
                .Returns((TEntity t) => t)
                .Callback((TEntity t) => data.ToList().Add(t));

            set.Setup(s => s.Remove(It.IsAny<TEntity>()))
                .Returns((TEntity t) => t)
                .Callback((TEntity t) => data.ToList().Remove(t));

            return set;
        }
    }
}
