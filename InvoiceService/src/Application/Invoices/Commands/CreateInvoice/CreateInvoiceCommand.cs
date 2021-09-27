using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest
    {
        public CreateInvoiceCommand()
        {
            lines = new List<InsertInvoiceLineDto>();
        }
        public Guid InvoiceId { get => Guid.NewGuid(); }
        public Guid? ClientId { get; set; }
        public IEnumerable<InsertInvoiceLineDto> lines { get; set; }
        public DateTimeOffset? InvoiceDate { get; set; }
    }
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand>
    {
        IInvoiceRepository _repo;
        public CreateInvoiceCommandHandler(IInvoiceRepository repository)
        {
            _repo = repository;
        }
        public Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = new Invoice
            {
                Id = request.InvoiceId,
                ClientId = request.ClientId,
                InvoiceDate = request.InvoiceDate
            };
            if (request.lines.Count() > 0)
            {
                invoice.Lines = request.lines.Select(l => new InvoiceLines
                {
                    Id =l.Id,
                    Amount = l.Amount,
                    InvoiceId = invoice.Id,
                    Item = l.Item,
                    Quantity = l.Quantity                  
                }).ToList();
            }
            _repo.Add(invoice);
            //_repo.Commit();
            return Unit.Task;
        }
    }
}
