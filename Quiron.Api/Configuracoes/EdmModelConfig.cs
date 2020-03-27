using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Quiron.Domain.Dto;

namespace Quiron.Api.Configuracoes
{
    public class EdmModelConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();

            odataBuilder.EntitySet<EspacoDto>("Espaco");

            return odataBuilder.GetEdmModel();
        }
    }
}