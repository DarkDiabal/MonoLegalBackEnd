using AutoMapper;
using MonoLegal.Core.Entities;
using MonoLegal.Core.Models.Request;
using MonoLegal.Core.Models.Response;

namespace MonoLegal.Api.Mappings
{
    /// <summary>
    /// Automapper class
    /// </summary>
    public class MappingProfile : Profile
    {

        /// <summary>
        /// Config automapper 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<InvoiceRequestBindingModel, InvoiceEntity>();
            CreateMap<InvoiceEntity, InvoiceResponseBindingModel > ();
        }
    }
}
