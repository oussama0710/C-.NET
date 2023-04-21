using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;     //be sure to use your own project's namespace!
public class FormController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Form");
    }
    [HttpPost]
    [Route("method")]
    public IActionResult Method(string Name, string DojoLocation, string FavouriteLocation, string comment)
    {
         ViewBag.Name = Name;
         ViewBag.DojoLocation = DojoLocation;
         ViewBag.FavouriteLocation = FavouriteLocation;
         ViewBag.comment = comment;
        return View("result");
    }
}