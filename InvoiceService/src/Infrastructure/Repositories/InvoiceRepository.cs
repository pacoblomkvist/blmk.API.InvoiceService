using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Infrastructure.Repositories
{
    public class InvoiceRepository: BaseMongoRepository<Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(IMongoContext context):base(context)
        {
        }
    }
}
