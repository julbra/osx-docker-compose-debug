using System.IO;
using System.IO.Compression;
using IdGen;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;


namespace Hello.Api
{
    public class Startup
    {
        public static readonly IContractResolver ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc().AddJsonOptions(jo => { jo.SerializerSettings.ContractResolver = ContractResolver; });
            services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });
            services.AddResponseCompression(options => {
                                                options.Providers.Add<BrotliCompressionProvider>();
                                                options.EnableForHttps = true;
            });

            services.AddSingleton<IIdGenerator<long>>(new IdGenerator(0));
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
            app.UseResponseCompression();
        }
    }

    public class BrotliCompressionProvider : ICompressionProvider
    {

        public string EncodingName => "br";

        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream) => new BrotliStream(outputStream, CompressionMode.Compress);

    }
}