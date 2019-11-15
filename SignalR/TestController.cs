using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace SignalRTest.SignalR
{
    public class TestController : Controller
    {
        readonly IHubContext<TestHub, ITestHub> _hubContext;

        public TestController(IHubContext<TestHub, ITestHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Good()
        {
            _hubContext.Clients.All.good(new Random().Next(100));
            return Ok();
        }

        [HttpPost]
        public IActionResult Bad()
        {
            var json = "{ 'a' : 'b' }";
            object message = JsonConvert.DeserializeObject(json);
            _hubContext.Clients.All.bad(message);
            return Ok();
        }
    }
}