using InvoiceService.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommand:IRequest
    {
        public Guid InvoiceId { get; set; }
    }
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        IInvoiceRepository _repo;
        public DeleteInvoiceCommandHandler(IInvoiceRepository repository)
        {
            _repo = repository;
        }
        public Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
              _repo.Remove(request.InvoiceId);
            return Unit.Task;
        }
    }
}
