using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.SelfHost;
using static System.Net.Dns;

namespace CallData
{
    public class SelfHostingServer
    {
        private readonly HttpSelfHostServer server;

        public SelfHostingServer()
        {
            IPAddress ip = GetHostByName(GetHostName()).AddressList[0]; // current PC's IP
            var baseAdress = new Uri("http://" + ip + ":8000");
            var selfHostConfiguration = new HttpSelfHostConfiguration(baseAdress);
            selfHostConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: (new { id = RouteParameter.Optional })
                );
            server = new HttpSelfHostServer(selfHostConfiguration);
        }

        /// <summary>
        /// Start server
        /// </summary>
        public void Start()
        {
            server.OpenAsync();
        }
        /// <summary>
        /// Stop server
        /// </summary>
        public void Stop()
        {
            server.CloseAsync();
            server.Dispose();
        }
    }
}