using InvoiceService.Application.Invoices.Commands.CreateInvoice;
using InvoiceService.Application.Invoices.Commands.DeleteInvoice;
using InvoiceService.Application.Invoices.Queries.GetInvoiceById;
using InvoiceService.Application.Invoices.Queries.GetInvoices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ApiControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<IEnumerable<InvoiceDto>> Get()
        {
            return await Mediator.Send(new GetInvoicesQuery());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<InvoiceDto> Get(Guid id)
        {
            var command = new GetInvoiceByIdQuery { InvoiceId = id };
            return await Mediator.Send(command);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async void Post([FromBody] CreateInvoiceCommand command)
        {
             await Mediator.Send( command);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid  id)
        {
            var command = new DeleteInvoiceCommand { InvoiceId = id };
            Mediator.Send(command);
        }
    }
}
