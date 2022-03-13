using MongoDB.Bson;
using MongoDB.Driver;
using MonoLegal.Core.Entities;
using MonoLegal.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoLegal.Persistence.Implementations
{
    public class InvoiceCollection : IInvoiceCollection
    {
        /// <summary>
        /// Invoice Repository
        /// </summary>
        public InvoiceRepository _invoiceRepository = new InvoiceRepository();

        /// <summary>
        /// Invoice entity or collection
        /// </summary>
        public IMongoCollection<InvoiceEntity> invoiceCollection;

        /// <summary>
        /// Constructor for Invoice Collection
        /// </summary>
        public InvoiceCollection()
        {
            invoiceCollection = _invoiceRepository._db.GetCollection<InvoiceEntity>("Invoice");
        }

        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>List of Invoice Entity</returns>
        public async Task<List<InvoiceEntity>> GetInvoices()
        {
            return await invoiceCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        /// <summary>
        /// Method for update invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns>Replace one result</returns>
        public async Task<ReplaceOneResult> UpdateInvoice(InvoiceEntity invoice)
        {
            var filter = Builders<InvoiceEntity>.Filter.Eq(i => i.Id, invoice.Id);
            return await invoiceCollection.ReplaceOneAsync(filter, invoice);
        }
    }
}
