using FluentAssertions;
using NPGSQL.Collation.API.Persistence;
using NPGSQL.Collation.API.Persistence.Repositories;

namespace NPGSQL.Collation.UnitTests;

public class AuthorRepositoryTests : BaseTestRepository
{
    public AuthorRepository _authorRepository;

    public AuthorRepositoryTests()
    {
        _authorRepository = new AuthorRepository(_context);
    }

    [Theory]
    [InlineData("Dr. Seuss")]
    [InlineData("dr. seuss")]
    [InlineData("dR. seUss")]
    public async Task TestMethod(string name)
    {
        var normalizedName = "Dr. Seuss";

        var author = await _authorRepository.GetAuthorAsync(normalizedName);

        author.Should().NotBeNull();
    }
}