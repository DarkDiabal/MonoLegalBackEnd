using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonoLegal.Business.Interfaces;
using MonoLegal.Core.Models.Request;
using System;
using System.Threading.Tasks;

namespace MonoLegal.Api.Controllers
{
    /// <summary>
    /// Controller for invoices operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceBusiness _invoiceBusiness;

        /// <summary>
        /// Constructor for invoice controller
        /// </summary>
        /// <param name="invoiceBusiness"></param>
        public InvoiceController(IInvoiceBusiness invoiceBusiness)
        {
            _invoiceBusiness = invoiceBusiness ?? throw new ArgumentNullException(nameof(invoiceBusiness));
        }

        /// <summary>
        /// Get all invoices 
        /// </summary>
        /// <returns>List of invoices</returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _invoiceBusiness.GetInvoices();

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorResult);
        }

        /// <summary>
        /// Methof for update invoice
        /// </summary>
        /// <param name="model">Invoice request binding model</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(InvoiceRequestBindingModel model)
        {
            var result = await _invoiceBusiness.UpdateInvoice(model);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorResult);
        }
    }
}
