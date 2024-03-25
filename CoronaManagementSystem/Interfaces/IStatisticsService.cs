using CoronaManagementSystem.Models;

namespace CoronaManagementSystem.Interfaces
{
    public interface IStatisticsService
    {
        int GetAllNotVaccinated();
        List<DateTime> GetDatesOfIllness();
    }
}