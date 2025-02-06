using Microsoft.EntityFrameworkCore;
using NPGSQL.Collation.API.Persistence.Models;

namespace NPGSQL.Collation.API.Persistence.Repositories;

public class BookRepository(ApplicationDbContext _dbContext) : IBookRepository
{
    public async Task<Book?> GetBookAsync(string name)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(x => x.Title == name);
    }

    public async Task<List<Book>> GetBooksByAuthorAsync(string name)
    {
        return await _dbContext.Books.Where(x => x.AuthorId == name).ToListAsync();
    }
}