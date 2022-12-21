using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVC_DBMS.Controllers;

public class DatabaseController : Controller
{
    // GET
    public IActionResult DatabaseEditing()
    {
        return View(new TableModel());  
    }
    
    public IActionResult CreateTable(TableModel model)
    {
        Table table = new()
        {
            Name = model.Name
        };

        Database.Instance.Tables[model.Name] = table;
        ViewBag.Table = table;
 
        return View("TableEditing");    
    }
    
    [HttpPost] 
    public IActionResult FinishTableEditing(string tableJson)
    {
        Table table = JsonConvert.DeserializeObject<Table>(tableJson)!;
        Database.Instance.Tables[table.Name] = table;

        return View("DatabaseEditing");
    }

    public IActionResult TableEditing(string tableToEdit)
    {
        ViewBag.Table = Database.Instance.Tables[tableToEdit];
        
        return View("TableEditing");
    }

    public IActionResult TableDeleting(string tableToDelete)
    {
        Database.Instance.Tables.Remove(tableToDelete);
        
        return View("DatabaseEditing");
    }

    public IActionResult SaveDatabase()
    {
        string json = JsonConvert.SerializeObject(Database.Instance);
        
        System.IO.File.WriteAllText($"{Database.Instance.Name}.json", json);
        
        return View("DatabaseEditing");
    }

    public IActionResult ReturnToHome()
    {
        return RedirectToAction("Index", "Home");
    }
}