using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_DBMS.Models;
using Newtonsoft.Json;

namespace MVC_DBMS.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new HomeModel());
    }
    
    public IActionResult DatabaseLobby(HomeModel model)
    {
        if (model.Name == "admin")
        {
            Role.Value = RoleType.Admin;
        }
        else if (model.Name == "user")
        {
            Role.Value = RoleType.User;
        }
        else
        {
            ViewBag.ErrorMessage = "Wrong password";
            return View("Index");
        }
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult CreateDatabase(HomeModel model)
    {
        Database.Create(model.Name);
        
        return RedirectToAction("DatabaseEditing", "Database", null);
    }

    public IActionResult LoadDatabase(HomeModel model)
    {
        try
        {
            string json = System.IO.File.ReadAllText($"{model.Name}.json");
            Database.Instance = JsonConvert.DeserializeObject<Database>(json)!;
            return RedirectToAction("DatabaseEditing", "Database");
        }
        catch
        {
            ViewBag.ErrorMessage = "Incorrect file";
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    public IActionResult AcceptPassword()
    {
        throw new NotImplementedException();
    }
}