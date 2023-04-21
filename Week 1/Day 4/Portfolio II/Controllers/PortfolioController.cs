using Microsoft.AspNetCore.Mvc;
namespace Potrfolio.Controllers;     //be sure to use your own project's namespace!
    public class PortfolioController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public ViewResult Index()
    {
        // will attempt to serve 
            // Views/Hello/Index.cshtml
        // or if that file isn't there:
            // Views/Shared/Index.cshtml
        return View();
    }

        [HttpGet]       //type of request
        [Route("projects")]     //associated route string (exclude the leading /)
        public ViewResult project()
        {
            return View("Project");
        }
        [HttpGet]       //type of request
        [Route("Contact")]     //associated route string (exclude the leading /)
        public ViewResult Contact()
        {
            return View("Contact");
        }
    }