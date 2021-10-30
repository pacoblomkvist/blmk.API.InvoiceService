using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Application.Invoices.Commands.CreateInvoice;
using InvoiceService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest
    {

        public UpdateInvoiceCommand()
        {
            lines = new List<InsertInvoiceLineDto>();
        }
        public Guid InvoiceId { get; set; }
        public Guid? ClientId { get; set; }
        public IEnumerable<InsertInvoiceLineDto> lines { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public bool Charged { get; set; }
    }

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand>
    {
        IInvoiceRepository _repo;
        public UpdateInvoiceCommandHandler(IInvoiceRepository repository)
        {
            _repo = repository;
        }
        public Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = new Invoice
            {
                Id = request.InvoiceId,
                ClientId = request.ClientId,
                InvoiceDate = request.InvoiceDate,
                Charged = request.Charged,
            };
            if (request.lines.Count() > 0)
            {
                invoice.Lines = request.lines.Select(l => new InvoiceLines(l.Quantity, invoice.Id, l.Item, l.Amount)).ToList();
            }
            _repo.Update(invoice);
            //_repo.Commit();
            return Unit.Task;
        }
    }
}
