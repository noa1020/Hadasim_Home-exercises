using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagementSystem.Services
{
    public class VaccinationService : IVaccinationService
    {
        private readonly AppDbContext _context;

        public VaccinationService(AppDbContext context)
        {
            _context = context;
        }
        //Get all vaccination
        public List<Vaccination> GetAll()
        {
            return _context.Vaccinations.ToList();
        }

        //Get vaccination by id
        public async Task<Vaccination?> GetById(int id)
        {
            return await _context.Vaccinations.FirstOrDefaultAsync(a => a.VaccinationId == id);
        }
        //Add a new vaccination to the database
        public async Task<bool> Add(Vaccination newVaccination)
        {
            try
            {
                _context.Vaccinations.Add(newVaccination);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
        // Update an existing vaccination in the database
        public async Task<bool> Update(Vaccination newVaccination)
        {
            try
            {
                var existingVaccination = await _context.Vaccinations.FirstOrDefaultAsync(v => v.VaccinationId == newVaccination.VaccinationId);
                if (existingVaccination == null)
                {
                    return false;
                }
                // Update vaccination properties
                existingVaccination.Manufacturer = newVaccination.Manufacturer ?? existingVaccination.Manufacturer;
                existingVaccination.VaccinationName = newVaccination.VaccinationName != default ? newVaccination.VaccinationName : existingVaccination.VaccinationName;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating vaccination: {ex.Message}");
            }
        }

        // Delete a vaccination from the database
        public async Task<bool> Delete(int id)
        {
            try
            {
                var Vaccination = await _context.Vaccinations.FirstOrDefaultAsync(v => v.VaccinationId == id);
                if (Vaccination == null)
                {
                    return false;
                }
                _context.Vaccinations.Remove(Vaccination);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting vaccination with ID {id}: {ex.Message}");
            }
        }

    }
}
