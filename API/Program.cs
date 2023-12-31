using Business;
using Business.GraphQL.Query;
using Business.GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Modelli;
using Modelli.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<ECommerceDbContext>(opt =>
    opt.UseSqlServer($"Server=mssql-server;Database=Ecommerce;User Id=sa;Password=p4ssw0rD;Encrypt=False"));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business.Business>();

builder.Services
    .AddGraphQLServer()
    .AllowIntrospection(true)
    .RegisterDbContext<ECommerceDbContext>(DbContextKind.Pooled)
    .AddQueryType<GqlQuery>()
    .AddType<UtenteObjectType>()
    .AddType<ProdottoObjectType>()
    .AddType<AcquistoObjectType>()
    .AddProjections()
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
