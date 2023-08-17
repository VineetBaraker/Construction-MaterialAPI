using concrete.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace concrete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly DataContext _context;

        public MaterialController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Material>>> GetMaterials()
        {
            return Ok(await _context.Materials.ToListAsync());


        }
        [HttpPost]
        public async Task<ActionResult<List<Material>>> CreateMaterials(Material grade)
        {
            _context.Materials.Add(grade);
            await _context.SaveChangesAsync();
            return Ok(await _context.Materials.ToListAsync());


        }
        [HttpPut]
        public async Task<ActionResult<List<Material>>> UpdateMaterials(Material grade)
        {
            var dbGrade = await _context.Materials.FindAsync(grade.Id);
            if (dbGrade == null)
            {
                return BadRequest("Grade Not Found");
            }
            dbGrade.cementbrand = grade.cementbrand;
            dbGrade.gradeofcement = grade.gradeofcement;
            dbGrade.bricktype = grade.bricktype;
            dbGrade.gradeofaggregate = grade.gradeofaggregate;
            await _context.SaveChangesAsync();
            return Ok(await _context.Materials.ToListAsync());


        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Material>>> DeleteMaterials(int id)
        {
            var dbGrade = await _context.Materials.FindAsync(id);
            if (dbGrade == null)
            { 
               return BadRequest("Grade Not Found");
            }
            _context.Materials.Remove(dbGrade);
               await _context.SaveChangesAsync();
            return Ok(await _context.Materials.ToListAsync());


        }
       

    }
}
