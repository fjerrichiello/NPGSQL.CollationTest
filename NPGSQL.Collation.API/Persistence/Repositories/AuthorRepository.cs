using Microsoft.EntityFrameworkCore;
using NPGSQL.Collation.API.Persistence.Models;

namespace NPGSQL.Collation.API.Persistence.Repositories;

public class AuthorRepository(ApplicationDbContext _dbContext) : IAuthorRepository
{
    public async Task<Author?> GetAuthorAsync(string name)
    {
        return await _dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId == name);
    }
}