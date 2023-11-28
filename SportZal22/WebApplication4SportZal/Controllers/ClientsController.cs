using Microsoft.AspNetCore.Mvc;
using WebApplication4SportZal.Models;

namespace WebApplication4SportZal.Controllers
{
    [ApiController]
    [Route("/clients")]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var db = new SportContext();
            var clin = db.Clients.SingleOrDefault(s => s.Id == id);
            if (clin == null)
                return NotFound();
            return Ok(clin);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var db = new SportContext();
            return Ok(db.Clients);
        }
        [HttpPost]
        public IActionResult Add(Client clin)
        {
            var db = new SportContext();
            db.Clients.Add(clin);
            db.SaveChanges();
            return Ok(clin);
        }
        [HttpPut]
        public IActionResult Edit(Client clin)
        {
            var db = new SportContext();
            db.Clients.Update(clin);
            db.SaveChanges();
            return Ok(clin);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new SportContext();
            var clin = db.Clients.SingleOrDefault(s => s.Id == id);
            if (clin == null)
                return NotFound();
            return Ok(clin);
        }
    }
}
