using InvoiceService.Domain.Common;
using InvoiceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Application.Common.Interfaces
{
    public interface IRepository<T>: IDisposable where T : IBaseEntity
    {
        void Add(T obj);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(Guid id);
    }
}
