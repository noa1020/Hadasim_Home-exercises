using CoronaManagementSystem.Data;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        //Get all users
        public List<User> GetAll()
        {
            List<User> users = _context.Users.ToList();
            List<UserVaccination?> vaccinations = [.. _context.UserVaccinations];
            users.ForEach(user =>
            {
                user.Vaccinations = vaccinations.FindAll(Vaccination => Vaccination?.UserId == user.UserId);
            });
            return users;
        }

        //Get user by id
        public async Task<User?> GetById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        // Add a new user to the database
        public async Task<bool> Add(User newUser)
        {
            try
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding user: {ex.Message}");
            }
        }

        // Update an existing user in the database
        public async Task<bool> Update(User newUser)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == newUser.UserId);
                if (existingUser == null)
                {
                    return false;
                }
                // Update user properties
                existingUser.FirstName = newUser.FirstName ?? existingUser.FirstName;
                existingUser.LastName = newUser.LastName ?? existingUser.LastName;
                existingUser.DateOfBirth = newUser.DateOfBirth != default ? newUser.DateOfBirth : existingUser.DateOfBirth;
                existingUser.Landlinephone = newUser.Landlinephone ?? existingUser.Landlinephone;
                existingUser.MobilePhone = newUser.MobilePhone ?? existingUser.MobilePhone;
                existingUser.IllnessDate = newUser.IllnessDate ?? existingUser.IllnessDate;
                existingUser.RecoveryDate = newUser.RecoveryDate ?? existingUser.RecoveryDate;
                existingUser.Image = newUser.Image ?? existingUser.Image;
                existingUser.City = newUser.City ?? existingUser.City;
                existingUser.Street = newUser.Street ?? existingUser.Street;
                existingUser.HouseNumber = newUser.HouseNumber ?? existingUser.HouseNumber;
                if (newUser.Vaccinations != null)
                {
                    List<UserVaccination> vaccinations = [.. _context.UserVaccinations];
                    vaccinations = vaccinations.FindAll(Vaccination => Vaccination?.UserId == existingUser.UserId);
                    vaccinations.ForEach(vaccination =>
                    {
                        if (!existingUser.Vaccinations.Contains(vaccination))
                            _context.UserVaccinations.Remove(vaccination);
                    });
                    existingUser.Vaccinations = newUser.Vaccinations;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating user: {ex.Message}");
            }

        }

        // Delete a user from the database
        public async Task<bool> Delete(string id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user == null)
                {
                    return false;
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting user with ID {id}: {ex.Message}");
            }
        }

    }
}
