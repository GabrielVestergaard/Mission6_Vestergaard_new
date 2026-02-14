using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Vestergaard_new.Models;

namespace Mission6_Vestergaard_new.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    
    public HomeController(MovieCollectionContext temp) //Constructor
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View(); 
    }
    
    [HttpGet]
    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Form(Application response)
    {
        _context.Applications.Add(response); //Add record to the database
        _context.SaveChanges();
        
        return View("Confirmation");
    }
}