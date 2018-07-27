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
    public class PiratesController : ControllerBase
    {
        private readonly PirateDbContext oPirateDbContext;
        public PiratesController(PirateDbContext pPirateDbContext)
        {
            this.oPirateDbContext = pPirateDbContext;
        }

        // GET api/pirates
        [HttpGet]
        public ActionResult<IEnumerable<Pirate>> Get()
        {
            var r = oPirateDbContext.Pirates.ToList(); 
            return r;
        }

        // GET api/pirates/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
           var pirate = oPirateDbContext.Pirates.Find(id);

           if(pirate == null) {
               return NotFound();
           }

           return new ObjectResult(pirate);
        }

        // POST api/pirates
        [HttpPost]
        public ActionResult Post([FromBody] Pirate pirate)
        {
            if(pirate == null) {
                return BadRequest();
            }

            oPirateDbContext.Add(pirate);
            oPirateDbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = pirate.PirateID }, pirate);
        }

        // PUT api/pirates/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pirate pirate)
        {
            if(pirate == null || pirate.PirateID != id) {
                return BadRequest();
            }

            var vPirate = oPirateDbContext.Pirates.SingleOrDefault(p => p.PirateID == id);

            if(vPirate == null) {
                return NotFound();
            }

            vPirate.Name = pirate.Name;
            vPirate.NickName = pirate.NickName;
            vPirate.PirateCrewID = pirate.PirateCrewID;
            vPirate.Position = pirate.Position;
            vPirate.Bounty = pirate.Bounty;

            oPirateDbContext.Pirates.Update(vPirate);
            oPirateDbContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/pirates/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pirate = oPirateDbContext.Pirates.Find(id);

            if(pirate == null) {
                return NotFound();
            }

            oPirateDbContext.Pirates.Remove(pirate);
            oPirateDbContext.SaveChanges();

            return NoContent();
        }
    }
}
