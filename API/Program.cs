using Business;
using Microsoft.EntityFrameworkCore;
using Modelli;
using Modelli.Repository;
using Business.GraphQL.Query;
using Business.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<ECommerceDbContext>(opt =>
    opt.UseSqlServer("Server=localhost,2433;Database=Ecommerce;User Id=sa;Password=p4ssw0rD;Encrypt=False"));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business.Business>();

builder.Services
    .AddGraphQLServer()
    .AllowIntrospection(true)
    .AddQueryType<GqlQuery>()
    .AddType<UtenteObjectType>()
    .AddType<ProdottoObjectType>()
    .AddType<AcquistoObjectType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapGraphQL("/webapi/Gql");

app.MapControllers();

app.Run();
