using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoronaManagementSystem.Validation;
namespace CoronaManagementSystem.Models;
public class Member
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? MemberId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public string? Landlinephone { get; set; }
    [Required]
    public string? MobilePhone { get; set; }
    public List<MemberVaccination>? Vaccinations { get; set; }
    public DateTime? IllnessDate { get; set; }
    public DateTime? RecoveryDate { get; set; }
    public string? Image { get; set; }
    [Required]
    [MaxLength(50)]
    public string? City { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Street { get; set; }
    [Required]
    public int? HouseNumber { get; set; }
}

