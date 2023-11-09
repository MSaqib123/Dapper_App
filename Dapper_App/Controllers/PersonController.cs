using Dapper_DB.Models.Doman;
using Dapper_DB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_App.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repo;
        public PersonController(IPersonRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var list =await _repo.GetListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}
    }
}
