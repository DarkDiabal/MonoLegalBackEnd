using MongoDB.Driver;
using MonoLegal.Core.Entities;
using MonoLegal.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonoLegal.Persistence.Implementations
{
    public class TemplateCollection : ITemplateCollection
    {
        /// <summary>
        /// Invoice Repository
        /// </summary>
        public InvoiceRepository _invoiceRepository = new InvoiceRepository();

        /// <summary>
        /// template entity or collection
        /// </summary>
        public IMongoCollection<TemplateEntity> templateCollection;

        /// <summary>
        /// Constructor for template collection
        /// </summary>
        public TemplateCollection()
        {
            templateCollection = _invoiceRepository._db.GetCollection<TemplateEntity>("Template");
        }

        /// <summary>
        /// Method for get template by code
        /// </summary>
        /// <param name="code">code for template</param>
        /// <returns>Template</returns>
        public async Task<TemplateEntity> GetTemplateByCode(string code)
        {
            var filter = Builders<TemplateEntity>.Filter.Eq(i => i.Code, code);
            return  await templateCollection.FindAsync(filter).Result.FirstAsync();
        }
    }
}
