using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CBeltExam.Models;
namespace CBeltExam.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    //!-----------------------------------USER-------------------------------------------------
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/users/create")]
    public IActionResult CreateUser(User NewUser)
    {
        if (ModelState.IsValid)
        {
            // Email exist ?
            if (_context.Users.Any(u => u.Email == NewUser.Email))
            {
                // YES
                ModelState.AddModelError("Email", "Email already taken, hope by you");
                return View("Index");
            }
            else
            {
                // NO
                // Hash Password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                System.Console.WriteLine(NewUser.Password);
                // Add
                _context.Add(NewUser);
                // Save
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userId", NewUser.UserId);
                return RedirectToAction("Dashboard");
            }
        }
        return View("Index");
    }

    [HttpPost("/users/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // Login
            // search for a user that match the login email
            var UserFromDB = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (UserFromDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //  verify Password 
            var result = hasher.VerifyHashedPassword(loginUser, hashedPassword: UserFromDB.Password, loginUser.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", UserFromDB.UserId);
            return RedirectToAction("Dashboard");
        }
        // 
        return View("Index");
    }

    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }

        int? userId = (int)HttpContext.Session.GetInt32("userId");
        List<Quest> PostedQuests = _context.Quests.Include(a => a.Creator).Where(c => c.UserId == userId).ToList();
        ViewBag.PostedQuests = PostedQuests;
        List<int> Ids = _context.Missions.Where(c => c.UserId == userId).Select(c => c.QuestId).ToList();

        List<Quest> JoinedQuests = _context.Quests.Include(a => a.Creator).Where(c => c.UserId != userId && Ids.Contains(c.QuestId)).ToList();
        ViewBag.JoinedQuests = JoinedQuests;
        return View("Dashboard");
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    //!-----------------------------------QUEST-------------------------------------------------
    public IActionResult NewQuest()
    {
        return View();
    }
    [HttpPost("/quests/create")]
    public IActionResult CreateQuest(Quest newQuest)
    {
        if (ModelState.IsValid)
        {
            newQuest.UserId = (int)HttpContext.Session.GetInt32("userId");
            _context.Add(newQuest);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View("NewQuest");
    }
    public IActionResult FindQuest()
    {
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        List<int> Ids = _context.Missions.Where(c => c.UserId == userId).Select(c => c.QuestId).ToList();

        List<Quest> AvailableQuests = _context.Quests.Include(a => a.Creator).Where(c => c.UserId != userId && !Ids.Contains(c.QuestId)).ToList();
        // ViewBag.AvailableQuests =_context.Missions.Include(c=>c.Quest).ThenInclude(o=> o.Creator).Where(t=> t.UserId != userId ).ToList();
        
        ViewBag.AvailableQuests = AvailableQuests;
        return View();
    }
    [HttpPost("/missions/create")]
    public IActionResult MissionCreate(Mission newMission)
    {
        System.Console.WriteLine($"----------QuestId = {newMission.QuestId}");
        newMission.UserId = (int)HttpContext.Session.GetInt32("userId");
        newMission.IsCompleted = false;
        
        _context.Add(newMission);
        Quest? questToUpdate = _context.Quests.FirstOrDefault(c => c.QuestId == newMission.QuestId);
        questToUpdate.PeopleOnQuest  = questToUpdate.PeopleOnQuest + 1;
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }
    //______________--------LEAVE Quest-------________________
    [HttpPost("/missions/destroy")]
    public IActionResult LeaveMission(Mission newMission)
    {
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        // System.Console.WriteLine($"---------------------------{QuestId}------------------");
        Mission RetrievedMission = _context.Missions.SingleOrDefault(m => m.UserId == userId && m.QuestId == newMission.QuestId);
        _context.Missions.Remove(RetrievedMission);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }
    //______________-------COMPLETE QUEST-------______________
    [HttpPost("/missions/update")]
    public IActionResult CompleteMission(Mission newMission)
    {
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        Mission RetrievedMission = _context.Missions.SingleOrDefault(m => m.UserId == userId && m.QuestId == newMission.QuestId);
        RetrievedMission.IsCompleted = true;
        RetrievedMission.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}