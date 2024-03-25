using System.ComponentModel.DataAnnotations;
using CoronaManagementSystem.Validation;
namespace CoronaManagementSystem.Models;

public class Vaccination
{
    [Key]
    public int VaccinationId { get; set; }

    [MaxLength(50)]
    [Required]
    private string? manufacturer;
    public string? Manufacturer
    {
        get => manufacturer;
        set => manufacturer = ValidationFunctions.IsValidString(value) ? value : throw new Exception("Invalid manufacturer name");
    }
    [MaxLength(50)]
    [Required]
    private string? vaccinationName;
    public string? VaccinationName
    {
        get => vaccinationName;
        set => vaccinationName = ValidationFunctions.IsValidString(value) ? value : throw new Exception("Invalid vaccination name");
    }
}
