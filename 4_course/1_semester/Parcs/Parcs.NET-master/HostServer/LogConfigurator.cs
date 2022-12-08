using System;
using Serilog;

namespace HostServer
{
    public static class LogConfigurator
    {
        public static void Configure()
        {
            const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} {Properties}{NewLine}{Exception}";

            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithThreadId()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.RollingFile("HostServer.log.txt", outputTemplate: outputTemplate);

            string connectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.LogConnectionString);

            if (!String.IsNullOrWhiteSpace(connectionString))
            {
                log.WriteTo.MSSqlServer(connectionString, "LogEntries", autoCreateSqlTable: true);
            }

            string elasticSearchUrl = Environment.GetEnvironmentVariable(EnvironmentVariables.LogElasticSearchUrl);

            if (!String.IsNullOrWhiteSpace(elasticSearchUrl))
            {
                log.WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(elasticSearchUrl))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = Serilog.Sinks.Elasticsearch.AutoRegisterTemplateVersion.ESv5
                });
            }

            Log.Logger = log.CreateLogger();
        }
    }
}
