using CriptoSigilo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CriptoSigilo.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View(new MensagemSigilosa());
		}

		[HttpPost]
		public IActionResult Index(MensagemSigilosa mensagemSigilosa)
		{
			mensagemSigilosa.Processar();
			return View(mensagemSigilosa);
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
}
