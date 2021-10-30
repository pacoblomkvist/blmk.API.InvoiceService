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
        public Guid? ClientId { get; set; }
        public IEnumerable<InsertInvoiceLineDto> lines { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
    }
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand>
    {
        IInvoiceRepository _repo;
        public CreateInvoiceCommandHandler(IInvoiceRepository repository)
        {
            _repo = repository;
        }
        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoicesThisYear = (await _repo.GetAllThat(c => c.Year == DateTime.Now.Year));
            var number = 0;
            if (invoicesThisYear.Any())
            {
                number = invoicesThisYear.Max(c => c.Number);
            }
            number += 1;


            var invoice = new Invoice(request.ClientId, request.InvoiceDate,
                charged: false, invoiceNumber: number, invoiceYear: request.InvoiceDate.Year);

            if (request.lines.Any())
            {
                invoice.Lines = request.lines.Select(l => new InvoiceLines(l.Quantity, invoice.Id, l.Item, l.Amount)).ToList();
            }

            _repo.Add(invoice);
            return await Unit.Task;
        }
    }
}
