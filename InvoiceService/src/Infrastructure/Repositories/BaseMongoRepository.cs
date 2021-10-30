using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Infrastructure.Repositories
{
    public class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : Domain.Common.IBaseEntity
    {
        IMongoContext _context;
        protected IMongoCollection<TEntity> DbSet;

        public BaseMongoRepository(IMongoContext invoiceContext)
        {
            _context = invoiceContext;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async virtual void Add(TEntity obj)
        {
            await DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(entity => entity.Id == id);
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {

            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.ReplaceOneAsync(entity => entity.Id == obj.Id, obj);
        }

        public async virtual void Remove(Guid id)
        {
            await DbSet.DeleteOneAsync(entity => entity.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllThat(Expression<Func<TEntity, bool>> expression)
        {
            var result = await DbSet.FindAsync(expression);
            return result.ToList();
        }
    }
}
