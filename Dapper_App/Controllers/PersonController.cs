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
        public async Task <IActionResult> Create(int? id)
        {
            Person obj = new Person();
            if (id > 0)
            {
                obj =await  _repo.GetByIdAsync(id.Value);
            }
            return View(obj);
        }
        
        [HttpPost]
        public async Task <IActionResult> Create(Person dto)
        {
            if (ModelState.IsValid)
            {
                string message;
                if (dto.Id > 0)
                {
                    bool update = await _repo.UpdateAsync(dto);
                    if (update)
                        message = "Updated Successfuly";
                }
                else
                {
                    bool add = await _repo.AddAsync(dto);
                    if (add)
                        message = "Added Successfuly";
                    
                }
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(dto);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Person obj =await _repo.GetByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            var deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                TempData["msg"] = "Delete Success Fully";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Failed";
            return View();
        }

    }
}
