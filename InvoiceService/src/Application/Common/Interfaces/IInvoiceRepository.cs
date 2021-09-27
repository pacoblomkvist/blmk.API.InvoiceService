using InvoiceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Application.Common.Interfaces
{
    public interface IInvoiceRepository :IRepository<Invoice>
    {
    }
}
