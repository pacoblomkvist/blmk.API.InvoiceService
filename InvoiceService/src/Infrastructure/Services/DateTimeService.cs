using InvoiceService.Application.Common.Interfaces;
using System;

namespace InvoiceService.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
