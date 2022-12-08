using Serilog;
using System;

namespace DaemonPr
{
    public static class LogConfigurator
    {
        public static void Configure()
        {
            const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} {Properties}{NewLine}{Exception}";

            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithThreadId()
                .Enrich.WithMachineName()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.RollingFile("Daemon.log.txt", outputTemplate: outputTemplate);

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
