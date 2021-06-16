using System.Linq;
using System.Threading.Tasks;
using Dotnet5.API.CRUD.EF.Data;
using Dotnet5.API.CRUD.EF.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.API.CRUD.EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsController : ControllerBase
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public GadgetsController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGadtets()
        {
            var allGadgets = _myWorldDbContext.Gadgets.ToList();
            return Ok(allGadgets);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateGadget(Gadgets gadgets)
        {
            _myWorldDbContext.Gadgets.Add(gadgets);
            _myWorldDbContext.SaveChanges();
            return Ok(gadgets.Id);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadgets)
        {
            _myWorldDbContext.Update(gadgets);
            _myWorldDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = _myWorldDbContext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }

            _myWorldDbContext.Gadgets.Remove(gadgetToDelete);
            _myWorldDbContext.SaveChanges();
            return NoContent();
        }
    }
}