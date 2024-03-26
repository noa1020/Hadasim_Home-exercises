using CoronaManagementSystem.Data;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagementSystem.Data;
public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    //Get all members from the datbase
    public async Task<List<Member>?> GetAllMembers()
    {
        return await _context.Members.ToListAsync();
    }

    //Add new member to the datbase
    public async Task<bool> DeleteMember(Member member)
    {
        _context.Members.Remove(member);
        await SaveChanges();
        return true;
    }

    //Get member by Id from the datbase
    public async Task<Member?> GetMemberById(string id)
    {
        return await _context.Members.FirstOrDefaultAsync(u => u.MemberId == id);
    }

    //Add new member to the datbase
    public async Task<bool> AddMember(Member newMember)
    {
        _context.Members.Add(newMember);
        await SaveChanges();
        return true;
    }

    //Update member in the datbase
    public async Task<bool> UpdateMember(Member member)
    {
        _context.Members.Update(member);
        await SaveChanges();
        return true;
    }

    //Get all vaccination from the datbase
    public async Task<List<Vaccination>?> GetAllVaccinations()
    {
        return await _context.Vaccinations.ToListAsync();
    }

    //Delete vaccination to the datbase
    public async Task<bool> DeleteVaccination(Vaccination vaccination)
    {
        _context.Vaccinations.Remove(vaccination);
        await SaveChanges();
        return true;
    }

    //Get vaccination by Id from the datbase
    public async Task<Vaccination?> GetVaccinationById(int id)
    {
        return await _context.Vaccinations.FirstOrDefaultAsync(a => a.VaccinationId == id);
    }

    //Add new vaccination to the datbase
    public async Task<bool> AddVaccination(Vaccination newVaccination)
    {
        _context.Vaccinations.Add(newVaccination);
        await SaveChanges();
        return true;
    }

    //Update vaccination in the datbase
    public async Task<bool> UpdateVaccination(Vaccination vaccination)
    {
        _context.Vaccinations.Update(vaccination);
        await SaveChanges();
        return true;
    }

    //Get all Members vaccination from the datbase
    public async Task<List<MemberVaccination>?> GetAllMemberVaccinations()
    {
        return await _context.MemberVaccinations.ToListAsync(); 
    }
    //Delete vaccination of member
    public async Task<bool> DeleteMemberVaccination(MemberVaccination vaccination)
    {
         _context.MemberVaccinations.Remove(vaccination);
        await SaveChanges();
        return true;
    }

    //Update datbase
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
