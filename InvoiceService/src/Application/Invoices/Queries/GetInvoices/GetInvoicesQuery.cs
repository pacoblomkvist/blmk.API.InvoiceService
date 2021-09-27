using AutoMapper;
using InvoiceService.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Queries.GetInvoices
{
    public class GetInvoicesQuery: IRequest<IEnumerable<InvoiceDto>>
    {

    }
    public class GetInvoiceQueryHandler : IRequestHandler<GetInvoicesQuery, IEnumerable<InvoiceDto>>
    {
        private readonly IInvoiceRepository _repo;
        private readonly IMapper _mapper;
        public GetInvoiceQueryHandler(IInvoiceRepository repository, IMapper mapper)
        {
            _repo = repository;
           _mapper = mapper;
        }
        public async Task<IEnumerable<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = (await _repo.GetAll());
            return invoices.Select(c => _mapper.Map<InvoiceDto>(c)).ToList();
        }
    }
}
