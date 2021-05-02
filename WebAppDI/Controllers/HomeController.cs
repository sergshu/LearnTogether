using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppDI.Data;
using WebAppDI.Models;
using WebAppDI.Services;

namespace WebAppDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LtContext _contex;
        private readonly IMapper _mapper;
        private readonly IInitials _initials;
        private readonly HttpClient _client;

        public HomeController(
            ILogger<HomeController> logger, 
            LtContext context, 
            IMapper mapper,
            IInitials initials,
            IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _contex = context;
            _mapper = mapper;
            _initials = initials;
            _client = clientFactory.CreateClient("client1");
        }

        public IActionResult Index()
        {
            var model = new IndexModel { TestItems = _mapper.Map<List<TestItemView>>(_contex.TestItems.ToList()) };
            foreach(var item in model.TestItems)
            {
                item.Initials = _initials.Get(item);
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
