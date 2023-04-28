using LX.TestPlatform.Data;
using LX.TestPlatform.Entities;
using LX.TestPlatform.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPlatform.Repositories;

public class UserRepository : IBaseRepository<User>
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(User entity)
    {
        await _db.Users.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public IQueryable<User> GetAll()
    {
        return _db.Users;
    }

    public async ValueTask DeleteAsync(User entity)
    {
        _db.Users.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public ValueTask UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}