using MonoLegal.Core.Entities;
using System.Threading.Tasks;

namespace MonoLegal.Persistence.Interfaces
{
    public interface ITemplateCollection
    {
        /// <summary>
        /// Method for get template by code
        /// </summary>
        /// <param name="code">code for template</param>
        /// <returns>Template</returns>
        public Task<TemplateEntity> GetTemplateByCode(string code);
    }
}
