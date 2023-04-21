using Microsoft.AspNetCore.Mvc;
namespace Potrfolio.Controllers;     //be sure to use your own project's namespace!
    public class PortfolioController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public string Index()
        {
            return "This is my index";
        }

        [HttpGet]       //type of request
        [Route("projects")]     //associated route string (exclude the leading /)
        public string project()
        {
            return "These are my projects";
        }
        [HttpGet]       //type of request
        [Route("Contacts")]     //associated route string (exclude the leading /)
        public string Contact()
        {
            return "These are my Contacts";
        }
    }