using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NPGSQL.Collation.API.Persistence;

namespace NPGSQL.Collation.UnitTests;

public abstract class BaseTestRepository : IDisposable
{
    private readonly SqliteConnection _connection;
    protected readonly ApplicationDbContext _context;

    protected BaseTestRepository()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new ApplicationDbContext(options);
        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _context.Dispose();
        _connection.Close();
        _connection.Dispose();
    }
}