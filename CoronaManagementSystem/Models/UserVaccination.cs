using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CoronaManagementSystem.Models;

public class UserVaccination
{
    [Key]
    public required int UserVaccinationId { get; set; }
    [ForeignKey("Users")]
    public required string UserId { get; set; }
    [ForeignKey("Vaccinations")]
    public required int VaccinationId { get; set; }
    public required DateTime VaccinationDate { get; set; }
}

