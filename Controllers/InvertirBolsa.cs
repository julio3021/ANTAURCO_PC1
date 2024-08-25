using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ANTAURCO_PC1.Models;
namespace ANTAURCO_PC1.Controllers
{

    public class InvertirBolsa : Controller
    {
        private readonly ILogger<InvertirBolsa> _logger;

        public InvertirBolsa(ILogger<InvertirBolsa> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Operacion(Operaciones operacion)
        {
            if (operacion.Instrumentos == null || !operacion.Instrumentos.Any())
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un instrumento.");
                return View("Index", operacion);
            }

            operacion.CalcularOperacion();
            ViewData["listaOperaciones"] = new List<Operaciones> { operacion };
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}