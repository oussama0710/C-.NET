using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {

        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var RandomStr = new char[14];
        var random = new Random();

        for (int i = 0; i < RandomStr.Length; i++)
        {
            RandomStr[i] = chars[random.Next(chars.Length)];
        }

        var FinalString = new String(RandomStr);
        ViewBag.FinalString = FinalString;
        int? IntRand = HttpContext.Session.GetInt32("Random");
        if (IntRand == null)
        {
            HttpContext.Session.SetInt32("Random", 1);
        }
        else{
            HttpContext.Session.SetInt32("Random", IntRand.Value +1);
        }
        ViewBag.IntRand = IntRand;
        return View("Index");
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
