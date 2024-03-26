using Microsoft.AspNetCore.Mvc;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Features;

namespace CoronaManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        this.statisticsService = statisticsService;
    }

    [HttpGet]
    [Route("/NotVaccinatedCount")]
    //Get count of all not vaccinated members 
    public async Task<int> GetAllNotVaccinated()
    {
        int NotVaccinated = await statisticsService.GetAllNotVaccinated();
        return NotVaccinated;
    }

    //Get all the dates someone was sick
    [HttpGet]
    [Route("/DatesOfIllness")]

    public async Task<List<DateTime>?> GetDatesOfIllness()
    {
        List<DateTime>? datesOfIllness = await statisticsService.GetDatesOfIllness();
        return datesOfIllness;
    }

}