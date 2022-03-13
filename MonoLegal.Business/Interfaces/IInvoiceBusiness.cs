using MonoLegal.Core.Models.Request;
using MonoLegal.Core.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoLegal.Business.Interfaces
{
    public interface IInvoiceBusiness
    {
        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>List of invoice binding model</returns>
        public Task<ResponseBindingModel<List<InvoiceResponseBindingModel>>> GetInvoices();

        /// <summary>
        /// Method for update invoice
        /// </summary>
        /// <param name="model">Invoice binding model</param>
        /// <returns></returns>
        public Task<ResponseBindingModel<string>> UpdateInvoice(InvoiceRequestBindingModel model);
    }
}
