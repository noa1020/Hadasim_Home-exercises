using Microsoft.AspNetCore.Mvc;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Features;

namespace CoronaManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VaccinationController : ControllerBase
    {
        private readonly IVaccinationService vaccinationService;

        public VaccinationController(IVaccinationService vaccinationService)
        {
            this.vaccinationService = vaccinationService;
        }

        //Get all vaccinations.
        [HttpGet]
        public async Task<List<Vaccination>?> GetAll()
        {
            List<Vaccination>? vaccinations = await vaccinationService.GetAll();
            return vaccinations;
        }

        //Add new vaccination.
        [HttpPost]
        public async Task<IActionResult> Add(Vaccination newvaccination)
        {
            if (newvaccination == null)
            {
                return BadRequest("vaccination object is null");
            }
            Vaccination? existingvaccination = await vaccinationService.GetById(newvaccination.VaccinationId!);
            if (existingvaccination != default)
            {
                return BadRequest("vaccination ID already exists");
            }
            try
            {
                var tasks = new List<Task> { vaccinationService.Add(newvaccination) };
                await Task.WhenAll(tasks);
                return CreatedAtAction(nameof(Add), new { id = newvaccination.VaccinationId }, newvaccination);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errorMessage = ex.Message });
            }
        }
        //Update an existing vaccination.
        [HttpPut]
        public async Task<IActionResult> Update(Vaccination vaccinationToUpdate)
        {
            if (vaccinationToUpdate == null)
            {
                return BadRequest("vaccination object is null");
            }
            Vaccination? vaccination = await vaccinationService.GetById(vaccinationToUpdate.VaccinationId!);
            if (vaccination == null)
            {
                return NotFound("vaccination not found");
            }
            try
            {
                await vaccinationService.Update(vaccinationToUpdate);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Delete vaccination by ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Vaccination? vaccination = await vaccinationService.GetById(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            try
            {
                await vaccinationService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
