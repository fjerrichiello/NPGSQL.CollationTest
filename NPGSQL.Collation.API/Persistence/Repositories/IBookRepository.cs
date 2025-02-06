using NPGSQL.Collation.API.Persistence.Models;

namespace NPGSQL.Collation.API.Persistence.Repositories;

public interface IBookRepository
{
    Task<Book?> GetBookAsync(string name);
    
    Task<List<Book>> GetBooksByAuthorAsync(string name);
}