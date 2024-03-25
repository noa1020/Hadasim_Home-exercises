using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoronaManagementSystem.Validation;
namespace CoronaManagementSystem.Models;
public class User
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    private string? userId;
    public string? UserId
    {
        get => userId;
        set => userId = ValidationFunctions.IsValidIsraeliId(value) ? value : throw new Exception("Invalid israeli id");
    }

    [MaxLength(50)]
    private string? firstName;
    public string? FirstName
    {
        get => firstName;
        set => firstName = ValidationFunctions.IsValidString(value) ? value : throw new Exception("Invalid first name");
    }

    [MaxLength(50)]
    private string? lastName;
    public string? LastName
    {
        get => lastName;
        set => lastName = ValidationFunctions.IsValidString(value) ? value : throw new Exception("Invalid last name");
    }

    [Required]
    private DateTime dateOfBirth;
    public DateTime DateOfBirth
    {
        get => dateOfBirth;
        set => dateOfBirth = ValidationFunctions.IsValidBirthDate(value) ? value : throw new Exception("Invalid date of birth");
    }

    private string? landlinephone;
    public string? Landlinephone
    {
        get => landlinephone;
        set => landlinephone = ValidationFunctions.IsValidIsraeliLandlinePhone(value) ? value : throw new Exception("Invalid landline phone");
    }

    private string? mobilePhone;
    public string? MobilePhone
    {
        get => mobilePhone;
        set => mobilePhone = ValidationFunctions.IsValidIsraeliMobilePhone(value) ? value : throw new Exception("Invalid mobile phone");
    }

    private List<UserVaccination?>? vaccinations;
    public List<UserVaccination?>? Vaccinations
    {
        get => vaccinations;
        set => vaccinations = value?.Count() < 5 ? value : throw new Exception("You cannot take more than 4 vaccines");
    }

    private DateTime? illnessDate;
    public DateTime? IllnessDate
    {
        get => illnessDate;
        set => illnessDate = (recoveryDate!=null && value > recoveryDate) ? throw new Exception("Recovery date will be only after illness date"): value;
    }

    private DateTime? recoveryDate;
    public DateTime? RecoveryDate
    {
        get => recoveryDate;
        set => recoveryDate = value < IllnessDate ? throw new Exception("Recovery date will be only after illness date") : value;
    }
    public string? Image { get; set; }
    private string? city;
    public string? City
    {
        get => city;
        set => city = ValidationFunctions.IsValidString(value) ? value : throw new Exception("Invalid city name");
    }
    private string? street;
    public string? Street
    {
        get => street;
        set => street = ValidationFunctions.IsValidString(value) ? value : throw new Exception("Invalid Street name");
    }

    private int? houseNumber;
    public int? HouseNumber
    {
        get => houseNumber;
        set => houseNumber = (value >= 0) ? value : throw new Exception("Invalid House number");
    }

}

