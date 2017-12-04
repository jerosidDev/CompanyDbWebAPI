using System.Web.Http;

namespace CompanyDbWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            //// issue with circular references
            //var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            //var dcs = new DataContractSerializer(typeof(TBALocation), null, int.MaxValue, false, true, null);
            //xml.SetSerializer<TBALocation>(dcs);
            //var dcs2 = new DataContractSerializer(typeof(ContractConsultant), null, int.MaxValue, false, true, null);
            //xml.SetSerializer<ContractConsultant>(dcs2);





            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
