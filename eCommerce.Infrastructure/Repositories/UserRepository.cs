using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EfDbContext _dbContext;
    public UserRepository(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        if (user is null) return null;

        return user;
    }
}