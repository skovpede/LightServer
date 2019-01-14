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
        
        private void AddCorsHeaders()
        {
            Response.Headers["Access-Control-Allow-Origin"] = "*";
            Response.Headers["Access-Control-Allow-Methods"] = "PUT,OPTIONS";
            Response.Headers["Access-Control-Allow-Headers"] = "Content-Type";
        }

        [HttpOptions("set/{id}")]
        public void Preflight(string id) => AddCorsHeaders();

        [HttpPut("set/{id}")]
        public async Task PutState(string id, [FromBody]PutModel wire)
        {
            AddCorsHeaders();
            var response = await client.PostAsJsonAsync(configuration.GetValue<string>("BridgeUrl"),
                new
                {
                    device = id,
                    state = wire.State ? "on" : "off"
                });
            response.EnsureSuccessStatusCode();
        }
    }

    public class PutModel
    {
        public bool State { get; set; }
    }

}
