using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LightServer
{
    public class SetController : Controller
    {
        readonly HttpClient client;
        private readonly IConfiguration configuration;

        public SetController(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
        }

        [HttpOptions("set/{id}")]
        public void Preflight(string id) => Response.Headers["Access-Control-Allow-Origin"] = "*";

        [HttpPut("set/{id}")]
        public async Task PutState(string id, [FromBody]bool state)
        {
            var response = await client.PostAsJsonAsync(configuration.GetValue<string>("BridgeUrl"),
                new
                {
                    device = id,
                    state = state ? "on" : "off"
                });
            response.EnsureSuccessStatusCode();
        }
    }
}
