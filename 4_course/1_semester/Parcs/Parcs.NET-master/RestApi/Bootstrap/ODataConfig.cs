using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Formatter;
using DataAccess.Logs;

namespace RestApi.Bootstrap
{
    public class ODataConfig
    {
        public static void RegisterLogEntryEndpoint(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<LogEntry>("LogEntries").EntityType.HasKey(l => l.LogEntryId);

            //config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());

            //Append XML/Atom & other default OData formats
            var odataFormatters = ODataMediaTypeFormatters.Create();
            config.Formatters.InsertRange(0, odataFormatters);
        }
    }
}