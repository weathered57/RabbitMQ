using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Business.Abstract;
using RabbitMQ.Entities;
using RabbitMQ.WebUI.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IProductsService _iProductService;

        public HomeController(ILogger<HomeController> logger, IPublishEndpoint publishEndpoint, IProductsService iProductService)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _iProductService = iProductService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> list = new List<ProductDto>();

            var products = _iProductService.GetList().Data;
            products.ForEach(x => list.Add(new ProductDto() { Id=x.Id,Name = x.Name, Description = x.Description, Cost = x.Cost }));

            return View(list);
        }
    }
}