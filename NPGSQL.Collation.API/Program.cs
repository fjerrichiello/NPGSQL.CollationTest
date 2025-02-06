using Microsoft.EntityFrameworkCore;
using NPGSQL.Collation.API.Persistence;
using NPGSQL.Collation.API.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

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
    async (IAuthorRepository authorRepository, string name) => await authorRepository.GetAuthorAsync(name));

app.MapGet("/books/author/{name}",
    async (IBookRepository bookRepository, string name) => await bookRepository.GetBooksByAuthorAsync(name));

app.MapGet("/books/{name}",
    async (IBookRepository bookRepository, string name) => await bookRepository.GetBookAsync(name));

app.Run();