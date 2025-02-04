using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NPGSQL.Collation.API.Persistence.Models;

[Index(nameof(AuthorId))]
public class Author
{
    [Key]
    public int Id { get; set; }

    public required string AuthorId { get; set; }
}