using NPGSQL.Collation.API.Persistence.Models;

namespace NPGSQL.Collation.API.Persistence.Repositories;

public interface IAuthorRepository
{
    Task<Author?> GetAuthorAsync(string name);
}