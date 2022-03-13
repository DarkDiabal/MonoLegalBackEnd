using AutoMapper;
using MonoLegal.Business.Helpers;
using MonoLegal.Business.Interfaces;
using MonoLegal.Core.Entities;
using MonoLegal.Core.Models.Request;
using MonoLegal.Core.Models.Response;
using MonoLegal.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static MonoLegal.Core.Enums.Reminder;

namespace MonoLegal.Business.Implementations
{
    public class InvoiceBusiness : IInvoiceBusiness
    {
        /// <summary>
        /// Property for invoice Collection
        /// </summary>
        private readonly IInvoiceCollection _invoiceCollection;

        /// <summary>
        /// Property for template Collection
        /// </summary>
        private readonly ITemplateCollection _templeateCollection;

        /// <summary>
        /// Property for template Collection
        /// </summary>
        private readonly INotificationHelper _notificationHelper;

        /// <summary>
        /// Property for automapper 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for invoice business
        /// </summary>
        /// <param name="invoiceCollection">Invoice repo collection</param>
        /// <param name="mapper">Automapper </param>
        public InvoiceBusiness(IInvoiceCollection invoiceCollection,
                               ITemplateCollection templeateCollection,
                               INotificationHelper notificationHelper,
                               IMapper mapper)
        {
            _invoiceCollection = invoiceCollection ?? throw new ArgumentNullException(nameof(invoiceCollection));
            _templeateCollection = templeateCollection ?? throw new ArgumentNullException(nameof(templeateCollection));
            _notificationHelper = notificationHelper ?? throw new ArgumentNullException(nameof(notificationHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>List of invoice binding model</returns>
        public async Task<ResponseBindingModel<List<InvoiceResponseBindingModel>>> GetInvoices()
        {
            ResponseBindingModel<List<InvoiceResponseBindingModel>> response = new ResponseBindingModel<List<InvoiceResponseBindingModel>>();
            try
            {

                var invoicesLst = await _invoiceCollection.GetInvoices();

                if (invoicesLst.Any())
                {
                    List<InvoiceResponseBindingModel> resultInvoiceList = new List<InvoiceResponseBindingModel>();
                    foreach (var item in invoicesLst)
                    {
                        var invoice = _mapper.Map<InvoiceEntity, InvoiceResponseBindingModel>(item);
                        invoice.PaidText = item.Paid ? "Si" : "No";
                        invoice.CreatedAt = item.CreatedAt.ToString("MM/dd/yyyy");
                        invoice.PaidAt = item.PaidAt.ToString("MM/dd/yyyy");
                        resultInvoiceList.Add(invoice);
                    }

                    response.Result = resultInvoiceList;

                }

                return response;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.ErrorResult = new ErrorMessageBindingModel
                {
                    Code = Convert.ToString((int)HttpStatusCode.InternalServerError),
                    Message = $"Ha ocurrido un error inesperado. {ex.Message}"
                };
                return response;
            }
        }

        /// <summary>
        /// Method for update invoice
        /// </summary>
        /// <param name="model">Invoice binding model</param>
        /// <returns></returns>
        public async Task<ResponseBindingModel<string>> UpdateInvoice(InvoiceRequestBindingModel model)
        {
            ResponseBindingModel<string> response = new ResponseBindingModel<string>();
            try
            {
                var invoiceEntity = _mapper.Map<InvoiceRequestBindingModel, InvoiceEntity>(model);
                var result = await _invoiceCollection.UpdateInvoice(invoiceEntity);

                if (result.MatchedCount > 0)
                {
                    TemplateEntity template = new TemplateEntity();
                    ReminderType reminderType = (ReminderType)Enum.Parse(typeof(ReminderType), model.Status);
                    switch (reminderType)
                    {
                        case ReminderType.SegundoRecordatorio:
                            template = await BuildTemplate(ReminderTypeTemplate.PrimerRecordatorio, model);
                            break;
                        case ReminderType.Desactivado:
                            template = await BuildTemplate(ReminderTypeTemplate.SegundoRecordatorio, model);
                            break;
                        default:
                            response.Succeeded = true;
                            response.ErrorResult = new ErrorMessageBindingModel
                            {
                                Code = Convert.ToString((int)HttpStatusCode.OK),
                                Message = $"Tipo de notificación no encontrado."
                            };
                            return response;
                    }

                    var sendEmail = await _notificationHelper.SendMail(template, model.ClientEmail);

                    if (sendEmail)
                    {
                        response.Succeeded = true;
                        response.Result = "Notificación enviada exitosamente.";
                    }
                    else
                    {
                        response.Succeeded = true;
                        response.Result = "No pudimos enviar la notificación.";
                    }

                    
                }
                else
                {
                    response.Succeeded = true;
                    response.ErrorResult = new ErrorMessageBindingModel
                    {
                        Code = Convert.ToString((int)HttpStatusCode.OK),
                        Message = $"La factura a editar no se encontro."
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.ErrorResult = new ErrorMessageBindingModel
                {
                    Code = Convert.ToString((int)HttpStatusCode.InternalServerError),
                    Message = $"Ha ocurrido un error inesperado. {ex.Message}"
                };
                return response;
            }
        }

        #region Private Methods

        private async Task<TemplateEntity> BuildTemplate(string code, InvoiceRequestBindingModel model)
        {
            var template = await _templeateCollection.GetTemplateByCode(code);

            if (template != null)
            {
                template.Template = template.Template.Replace("#Name", model.Client);
                template.Template = template.Template.Replace("#InvoiceCode", model.InvoiceCode);
                template.Template = template.Template.Replace("#Total", String.Format("{0:C}", model.InvoiceTotal));
                template.Template = template.Template.Replace("#SubTotal", String.Format("{0:C}", model.InvoiceSubTotal));
                template.Template = template.Template.Replace("#IVA", String.Format("{0:C}", model.Iva));
                template.Template = template.Template.Replace("#Retention", String.Format("{0:C}", model.Retention));
            }

            return template;
        }

        #endregion
    }
}
