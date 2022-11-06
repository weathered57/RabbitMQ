using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Business.Abstract;
using RabbitMQ.Entities;
using RabbitMQ.Entities.RabbitMQ;
using RabbitMQ.WebUI.Models;

namespace RabbitMQ.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IProductsService _iProductService;
        private readonly IOrderItemsService _iOrderItemsService;
        private readonly IOrderDetailsService _iOrderDetailsService;

        public OrderController(ILogger<OrderController> logger, IPublishEndpoint publishEndpoint, IProductsService iProductService, IOrderItemsService iOrderItemsService, IOrderDetailsService iOrderDetailsService)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _iProductService = iProductService;
            _iOrderItemsService = iOrderItemsService;
            _iOrderDetailsService = iOrderDetailsService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var lastDetail = "";
            var orderDetailsList = _iOrderDetailsService.GetList().Data;
            if (orderDetailsList.Count > 0)
                 lastDetail = orderDetailsList.OrderByDescending(x => x.Id).First().OrderNumber;
            var product = _iProductService.GetById(id).Data;

            var orderDetail = _iOrderDetailsService.Add(new OrderDetails() { OrderNumber = orderDetailsList.Count == 0 ? "202200001" : (int.Parse(lastDetail) + 1).ToString(), CreatedDate = DateTime.Now });

            _iOrderItemsService.Add(new OrderItems() { ProductId = product.Id, OrderId = orderDetail.Data.Id,CreatedDate=DateTime.Now });

            OrderProducts products = new OrderProducts();
            products.Product.Add(product);
            products.Quantity = 1;

            await _publishEndpoint.Publish<OrderDetail>(new
            {
                OrderNumber = orderDetail.Data.OrderNumber,
                OrderDatetime = DateTime.Now,
                Products = products

            });

            return View();
        }
    }
}
