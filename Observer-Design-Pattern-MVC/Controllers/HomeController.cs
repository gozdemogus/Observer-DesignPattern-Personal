using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Observer_Design_Pattern_MVC.Models;
using Observer_Design_Pattern_MVC.Services;

namespace Observer_Design_Pattern_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IOrderService _orderService;


    public HomeController(ILogger<HomeController> logger, IOrderService orderService)
    {
        _logger = logger;
             _orderService = orderService;

    }
    public IActionResult Index()
    {
        var order = new Order()
        {
            OrderNumber = "11283A454B",
            OrderDate = DateTime.Now,
            TotalAmount = 105.99m,
            OrderStatus = OrderStatuses.PendingPayment
        };

        return View(order);
    }

    [HttpPost]
    public IActionResult Index(Order order)
    {
        Console.WriteLine("Attaching Observers...");

        order.Logs.Add(string.Format("Observerlar ekleniyor...",
             order.OrderNumber, order.OrderStatus.ToString()));

        var smsObserver = new SmsObserver();
        var emailObserver = new EmailObserver();

        _orderService.Attach(smsObserver);
        _orderService.Attach(emailObserver);

        Console.WriteLine("Updating Order Status...");

        order.Logs.Add(string.Format("Siparis statusu guncelleniyor...",
             order.OrderNumber, order.OrderStatus.ToString()));

        _orderService.UpdateOrder(order);

        return View(order);
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

