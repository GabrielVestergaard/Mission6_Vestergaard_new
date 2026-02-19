using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View("Form", new Movie());
    }

    [HttpPost]
    public IActionResult Form(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();
            
            return View("Confirmation");
        }
        
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(response);
    }
    
    public IActionResult Collection ()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();
        
        return View(movies);
    }
 
    [HttpGet]
    public IActionResult Edit(int id)
    {
        Movie recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        
        return View("Form", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(updatedMovie);
            _context.SaveChanges();
            
            return RedirectToAction("Collection");
        }
        
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View("Form", updatedMovie);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("Collection");
    }
}