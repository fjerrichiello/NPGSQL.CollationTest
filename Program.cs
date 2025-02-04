using Microsoft.EntityFrameworkCore;
using NPGSQL.Collation.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CSVDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/authors/{name}",
    async (ApplicationDbContext db, string name) =>
    {
        return await db.Authors.FirstOrDefaultAsync(x => x.AuthorId == name);
    });

app.MapGet("/books/author/{name}",
    async (ApplicationDbContext db, string name) =>
    {
        return await db.Books.Where(x => x.AuthorId == name).ToListAsync();
    });

app.MapGet("/books/{name}",
    async (ApplicationDbContext db, string name) =>
    {
        return await db.Books.FirstOrDefaultAsync(x => x.Title == name);
    });

app.Run();