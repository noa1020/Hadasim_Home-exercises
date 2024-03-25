using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagementSystem.Services;
public class StatisticsService : IStatisticsService
{
    private readonly AppDbContext _context;
    public StatisticsService(AppDbContext context)
    {
        _context = context;
    }

    //Get count of all not vaccinated users 
    public int GetAllNotVaccinated()
    {

        List<User> users = new UserService(_context).GetAll();
        int count = 0;
        users.ForEach(user =>
        {
            if (user?.Vaccinations?.Count == 0) count++;
        });
        return count;
    }

    //Get all the dates someone was sick
    public List<DateTime> GetDatesOfIllness()
    {
        List<DateTime> datesOfIllness = new List<DateTime>();
        List<User> users = new UserService(_context).GetAll();
        users.ForEach(user =>
        {
            if (user.IllnessDate != null)
            {

                DateTime RecoveryDate = user.RecoveryDate != null ? (DateTime)user.RecoveryDate : DateTime.Today;
                DateTime date = (DateTime)user.IllnessDate;
                datesOfIllness.Add(date);
                while (date.Date != RecoveryDate.Date)
                {
                    date = date.AddDays(1);
                    datesOfIllness.Add(date);
                }
            }
        });
        return datesOfIllness;
    }
}
