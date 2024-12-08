using FruitPort.Api;
using FruitPort.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddProjections()
    .RegisterDbContextFactory<FruitContext>()
    .AddTypes()
    .AddFiltering()
    .AddSorting()
    .AddMutationConventions();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
