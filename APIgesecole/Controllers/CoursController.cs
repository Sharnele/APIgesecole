using APIgesecole.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIgesecole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursController : ControllerBase
    {
        // dependance au niveau du controlleur
        private readonly gesecoleContext _context;
        // on injecte la dependanve vers le constructeur
        public CoursController(gesecoleContext context)
        {
            _context = context;
        }
        // methode pour obtenir les cours à partir de la base de donnée
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cour>>> Getcours()
        {
            return await _context.Cours.ToListAsync();
        }
        //recuperer un cour à partir de son identifiant
        [HttpGet("{id}")]
        public async Task<ActionResult<Cour>> Getcoursbyid(int id)
        {
        
            var cour=await _context.Cours.Where(c =>c.Id.Equals(id)).FirstOrDefaultAsync();
            if (cour == null)
            {
                return NotFound();
            }

            return cour;
        }
        [HttpPost]

        //methode pour la creation des cours
        public async Task<ActionResult<Cour>> createcours(Cour cour)
        {
            // pour sauvegarder les donnees recu du navigateur
            _context.Cours.Add(cour);
            await _context.SaveChangesAsync(); 
            return CreatedAtAction (nameof (Getcoursbyid), new {id=cour.Id},cour); //on retourne l'information de creation
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cour>> deletecour(int id)
        {
            var cour = await _context.Cours.FindAsync(id);
            if (cour == null) 
            { 
                return NotFound();
            }
            _context.Cours.Remove(cour);
            await _context.SaveChangesAsync();
            return NoContent();

        }


        //[HttpGet]
        ////methode qui retourne une liste de cour
        //public IEnumerable <string> Get()
        //{
        //    return new List<string>() { "c#", "sql" };
        //}
    }
}
