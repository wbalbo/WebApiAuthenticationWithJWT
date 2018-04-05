using System.Data.Entity;
using System.Web.Http;
using DataAccessAPI.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DataAccessAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Define para que o EF inicialize o banco de dados usando a classe criada pra este propósito
            Database.SetInitializer(new Initializer());

            //Configura para retornar JSON em formato camel-case ao invés de pascal-case
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
