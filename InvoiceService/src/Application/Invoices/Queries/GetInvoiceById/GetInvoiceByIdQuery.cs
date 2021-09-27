using AutoMapper;
using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Application.Invoices.Queries.GetInvoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery: IRequest<InvoiceDto>
    {
        public Guid InvoiceId { get; set; }
    }
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDto>
    {
        IInvoiceRepository _repo;
        IMapper _mapper;
        public GetInvoiceByIdQueryHandler(IInvoiceRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repository;
        }
        public async Task<InvoiceDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map< InvoiceDto>(await _repo.GetById(request.InvoiceId));
        }
    }
}
