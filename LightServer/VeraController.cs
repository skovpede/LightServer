using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LightServer
{
    public class VeraController : Controller
    {
        public static object Last { get; private set; }
        private readonly IConfiguration configuration;
        Regex regex = new Regex(@"^dev_(\d+)");

        public VeraController(IConfiguration configuration) => this.configuration = configuration;
        public static void LoadFile()
        {
            //try
            //{
            //    Last = System.IO.File.ReadAllText(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "/latest.json");
            //}
            //catch (Exception) { }
        }

        [HttpPut("vera")]
        public void Index([FromBody]VeraModel.RootObject model)
        {
            var l =
                (from config in configuration.GetChildren()
                 let match = regex.Match(config.Key)
                 where match.Success
                 from d in model.devices
                 where d.id.ToString() == match.Groups[1].Value
                 from s in d.states.Where(state => state.service == "urn:upnp-org:serviceId:SwitchPower1").Take(1)
                 select new
                 {
                     d.id,
                     @on = s.value == "1",
                     name = config.Value
                 }).ToList();
            //System.IO.File.WriteAllText(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "/latest.json", JsonConvert.SerializeObject(l));
            Last = l;
        }
    }
}
