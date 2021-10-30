using AutoMapper;
using AutoMapper.EquivalencyExpression;
using InvoiceService.Application.Common.Mappings;
using InvoiceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Application.Invoices.Queries.GetInvoices
{
    public class InvoiceDto: IMapFrom<Invoice>
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public String InvoiceNumber { get; set; }
        public IList<InvoiceLineDto> Items { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public bool Charged { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDto>().ForMember(dst=> dst.Items, opt=> opt.MapFrom(src=> src.Lines));
            //profile.CreateMap<InvoiceLines, InvoiceLineDto>(MemberList.Source).EqualityComparison((src, dst) => src.Id == dst.Id);
        }
    }
    public class InvoiceLineDto : IMapFrom<InvoiceLines>
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public String Item { get; set; }
        public int Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Decimal TotalEuros { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InvoiceLines, InvoiceLineDto>();
        }
    }
}
