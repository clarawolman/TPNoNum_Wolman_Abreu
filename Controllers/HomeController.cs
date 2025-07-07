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
    public IActionResult Index() {
        return View();
    }
    public IActionResult Ingresar(string usuario, string password)
    {
        Integrante integrante = BD.BuscarIntegrante(usuario, password);
        if (integrante != null)
        {
            ViewBag.usuario = integrante.usuario;
            ViewBag.DNI = integrante.DNI;
            ViewBag.Telefono = integrante.telefono;
            ViewBag.FechaNacimiento = integrante.fechaNacimiento.ToShortDateString();
            ViewBag.Hobby = integrante.hobby;
            ViewBag.CantanteFav = integrante.cantanteFav;
            return View("Integrantes"); // 
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña no válidos.";
            return View("Index");
        }
    }

}
