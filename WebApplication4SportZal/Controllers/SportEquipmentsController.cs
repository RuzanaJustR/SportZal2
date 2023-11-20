using Microsoft.AspNetCore.Mvc;
using WebApplication4SportZal.Models;

namespace WebApplication4SportZal.Controllers
{
        [ApiController]
        [Route("/sportEquipments")]
    public class SportEquipmentsController : ControllerBase
    { 
            [HttpGet]
            [Route("{id}")]
            public IActionResult GetById(int id)
            {
                var db = new SportContext();
                var SportEquipments = db.SportEquipments.SingleOrDefault(s => s.Id == id);
                if (SportEquipments == null)
                    return NotFound();
                return Ok(SportEquipments);
            }
            [HttpGet]
            public IActionResult GetAll()
            {
                var db = new SportContext();
                return Ok(db.SportEquipments);
            }
            [HttpPost]
            public IActionResult Add(SportEquipment SportEquipments)
            {
                var db = new SportContext();
                db.SportEquipments.Add(SportEquipments);
                db.SaveChanges();
                return Ok(SportEquipments);
            }
            [HttpPut]
            public IActionResult Edit(SportEquipment SportEquipments)
            {
                var db = new SportContext();
                db.SportEquipments.Update(SportEquipments);
                db.SaveChanges();
                return Ok(SportEquipments);
            }
            [HttpDelete]
            [Route("{id}")]
            public IActionResult Delete(int id)
            {
                var db = new SportContext();
                var SportEquipments = db.SportEquipments.SingleOrDefault(s => s.Id == id);
                if (SportEquipments == null)
                    return NotFound();
                return Ok(SportEquipments);
            }
        }
}


