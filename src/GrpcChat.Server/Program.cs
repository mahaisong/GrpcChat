using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;
using System.Net;

namespace GrpcChat.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseKestrel(options => {
                        //options.Listen(IPAddress.Loopback, 5000); //HTTP  port 
                        //HTTPs port
                        options.Listen(IPAddress.Any, 5002, listen =>
                        { listen.UseHttps("C:\\mahaisong.pfx", "mahaisong");
                            listen.Protocols = HttpProtocols.Http2;
                        }) ; 

                    }).UseStartup<Startup>();
                         
                });
    }
}