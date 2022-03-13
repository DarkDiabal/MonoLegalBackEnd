using System;
using System.Collections.Generic;
using System.Text;

namespace MonoLegal.Core.Models.Request
{
    public class InvoiceRequestBindingModel
    {
        public string Id { get; set; }
        public string InvoiceCode { get; set; }
        public string Client { get; set; }
        public string ClientEmail { get; set; }
        public string City { get; set; }
        public string Nit { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal InvoiceSubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Retention { get; set; }
        public string Status { get; set; }
        public bool Paid { get; set; }
    }
}
