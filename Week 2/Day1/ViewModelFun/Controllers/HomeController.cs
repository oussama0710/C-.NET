using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;



    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string message = "Lorem Ipsum...";
        return View("Index", message);
    }

    [HttpGet("Numbers")]
    public IActionResult Numbers()
    {

        int[] numerals = new int[]
        {
            1,
            2,
            3,
            10,
            43,
            5
        };

        return View(numerals);
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        List<User> users = new List<User>();
        users.Add(new User("Moose", "Phillips"));
        users.Add(new User("Sarah"));
        users.Add(new User("Jerry"));
        users.Add(new User("Renee", "Ricky"));
        users.Add(new User("Barbara"));

        return View(users);
    }

    [HttpGet("user")]
    public IActionResult OneUser()
    {
        User firstUser = new User("Moose", "Phillips");
        return View(firstUser);
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