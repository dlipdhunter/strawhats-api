using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using strawhats_api.Models;

namespace strawhats_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PirateCrewsController : ControllerBase
    {
        private readonly PirateDbContext oPirateDbContext;
        public PirateCrewsController(PirateDbContext pPirateDbContext)
        {
            this.oPirateDbContext = pPirateDbContext;
        }

        // GET api/piratecrews
        [HttpGet]
        public ActionResult<IEnumerable<PirateCrew>> Get()
        {
            return oPirateDbContext.PirateCrews.ToList();
        }

        // GET api/piratecrews/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
           var pirateCrew = oPirateDbContext.PirateCrews.Find(id);

           if(pirateCrew == null) {
               return NotFound();
           }

           return new ObjectResult(pirateCrew);
        }

        // POST api/piratecrews
        [HttpPost]
        public ActionResult Post([FromBody] PirateCrew pirateCrew)
        {
            if(pirateCrew == null) {
                return BadRequest();
            }

            oPirateDbContext.Add(pirateCrew);
            oPirateDbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = pirateCrew.PirateCrewID }, pirateCrew);
        }

        // PUT api/piratecrews/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PirateCrew pirateCrew)
        {
            if(pirateCrew == null || pirateCrew.PirateCrewID != id) {
                return BadRequest();
            }

            var vPirateCrew = oPirateDbContext.PirateCrews.SingleOrDefault(p => p.PirateCrewID == id);

            if(vPirateCrew == null) {
                return NotFound();
            }

            vPirateCrew.Name = pirateCrew.Name;            

            oPirateDbContext.PirateCrews.Update(vPirateCrew);
            oPirateDbContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/piratecrews/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pirateCrew = oPirateDbContext.PirateCrews.Find(id);

            if(pirateCrew == null) {
                return NotFound();
            }

            oPirateDbContext.PirateCrews.Remove(pirateCrew);
            oPirateDbContext.SaveChanges();

            return NoContent();
        }
    }
}
