using MongoDB.Driver;
using MonoLegal.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoLegal.Persistence.Implementations
{
    public class InvoiceRepository
    {
        public MongoClient _client;

        public IMongoDatabase _db;

        public InvoiceRepository()
        {
            _client = new MongoClient("mongodb://127.0.0.1:27017");
            _db = _client.GetDatabase("monolegal-invoice");
        }
    }
}
