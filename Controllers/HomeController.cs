using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Nuova_cartella.Models;

namespace Nuova_cartella.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static List<Utente> Utenti= new List<Utente>();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        
    }
    public IActionResult Index()
    {
        dbContext db = new dbContext();
        db.Utenti.Add(new Utente{Nome="fatih", Cognome="islamovski",Email="@gmail.com" });
        db.SaveChanges();
        return View(db);
    }
    public IActionResult Prenota()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Prenotato( Utente u )
    {
        Utenti.Add(u);
        return View( Utenti );
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