using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LightServer
{
    public class StatusController : Controller
    {
        [HttpGet("status")]
        public object GetStatus()
        {
            Response.Headers["Access-Control-Allow-Origin"] = "*";
            return VeraController.Last;
        }
    }
}
