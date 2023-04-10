using CoderCarrer.DAL;
using CoderCarrer.Domain;
using CoderCarrer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CoderCarrer.Controllers
{
   
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IExtratorVaga vagasDao = new TrabalhaBrasilDAO();
            IExtratorVaga vagasfake = new VagasFake();
            List<Vaga> vagas = vagasDao.getVagas();
            List<Vaga> vagasfaike = vagasfake.getVagas();

            List<Vaga> vaga = new List<Vaga>();
            vaga.AddRange(vagas);


            return View(vaga);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Pesquisa()
        {
            IExtratorVaga vagasDao = new TrabalhaBrasilDAO();
            IExtratorVaga vagasfake = new VagasFake();
            List<Vaga> vagas = vagasDao.getVagas();
            List<Vaga> vagasfaike = vagasfake.getVagas();

            List<Vaga> vaga = new List<Vaga>();
            vaga.AddRange(vagas);


            return View(vaga);

        }
    }
}