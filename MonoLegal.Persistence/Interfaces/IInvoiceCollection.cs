using MongoDB.Driver;
using MonoLegal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoLegal.Persistence.Interfaces
{
    public interface IInvoiceCollection
    {
        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>List of Invoice Entity</returns>
        public Task<List<InvoiceEntity>> GetInvoices();

        /// <summary>
        /// Method for update invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns>Replace one result</returns>
        public Task<ReplaceOneResult> UpdateInvoice(InvoiceEntity invoice);
    }
}
