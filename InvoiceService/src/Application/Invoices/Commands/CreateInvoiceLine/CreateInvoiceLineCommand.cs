using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Commands.CreateInvoiceLine
{
   public class CreateInvoiceLineCommand: IRequest
    {
        Guid InvoiceId { get; set; }
        String Item { get; set; }
        int Quantity { get; set; }
        Decimal Amount { get; set; }
    }
    //public class CreateInvoiceLineCommandHandler: IRequestHandler<CreateInvoiceLineCommand, Guid>
    //{
    //    //public CreateInvoiceLineCommandHandler(IInvoiceLineRepository)
    //    //{

    //    //}
    //    public async Task<Guid> Handle(CreateInvoiceLineCommand request, CancellationToken cancellationToken)
    //    {
    //        return new Guid();
    //    }
    //}
}
