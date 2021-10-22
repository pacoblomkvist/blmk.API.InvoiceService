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
        public string InvoiceNumber { get; set; }
        public Guid? ClientId { get; set; }
        public IEnumerable<InsertInvoiceLineDto> lines { get; set; }
        public DateTimeOffset? InvoiceDate { get; set; }
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
                InvoiceNumber = request.InvoiceNumber
            };
            if (request.lines.Count() > 0)
            {
                invoice.Lines = request.lines.Select(l => new InvoiceLines
                {
                    Id = l.Id,
                    Amount = l.Amount,
                    InvoiceId = invoice.Id,
                    Item = l.Item,
                    Quantity = l.Quantity
                }).ToList();
            }
            _repo.Update(invoice);
            //_repo.Commit();
            return Unit.Task;
        }
    }
}
