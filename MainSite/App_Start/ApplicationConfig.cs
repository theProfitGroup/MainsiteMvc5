// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationConfig.cs" company="Company name">
//   -
// </copyright>
// <author>Igor Golovko</author>
// <summary>
//   Summary description for ApplicationConfig
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MainSite
{
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    /// <summary>
    /// Application settings class.
    /// </summary>
    public class ApplicationConfig
    {
        /// <summary>
        /// The register settings.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public static void RegisterSettings(HttpConfiguration configuration)
        {
            // Web API routes
            //configuration.MapHttpAttributeRoutes();

            // Convert all dates to UTC
            configuration.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            // write indented JSON
            configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            // write JSON property names with camel casing
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // preserve object references in JSON
            configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;
        }
    
    }
}