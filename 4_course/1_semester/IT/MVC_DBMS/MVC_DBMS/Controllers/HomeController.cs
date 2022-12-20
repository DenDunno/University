using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_DBMS.Models;

namespace MVC_DBMS.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new DatabaseModel());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult CreateDatabase(DatabaseModel model)
    {
        Database.Create(model.Name);
        
        return RedirectToAction("DatabaseEditing", "Database", null);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}