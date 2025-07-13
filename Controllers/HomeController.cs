using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPNoNum_Wolman_Abreu.Models;
using try_catch_poc.Models;


namespace TPNoNum_Wolman_Abreu.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Ingresar(string usuario, string password)
    {
        Integrante integrante = BD.BuscarIntegrante(usuario, password);
        if (integrante != null)
        {
            HttpContext.Session.SetString("usuario", integrante.usuario);
            HttpContext.Session.SetString("DNI", integrante.DNI.ToString());
            HttpContext.Session.SetString("Telefono", integrante.telefono);
            HttpContext.Session.SetString("FechaNacimiento", integrante.fechaNacimiento.ToShortDateString());
            HttpContext.Session.SetString("Hobby", integrante.hobby);
            HttpContext.Session.SetString("CantanteFav", integrante.cantanteFav);
            return RedirectToAction("Integrantes"); // 
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña no válidos.";
            return View("Index");
        }
    }
    public IActionResult Integrantes()
    {
        ViewBag.usuario = HttpContext.Session.GetString("usuario");
        ViewBag.DNI = HttpContext.Session.GetString("DNI");
        ViewBag.Telefono = HttpContext.Session.GetString("Telefono");
        ViewBag.FechaNacimiento = HttpContext.Session.GetString("FechaNacimiento");
        ViewBag.Hobby = HttpContext.Session.GetString("Hobby");
        ViewBag.CantanteFav = HttpContext.Session.GetString("CantanteFav");
        if (string.IsNullOrEmpty(ViewBag.usuario))
        {
            return RedirectToAction("Index");
        }
        return View();
    }

}
