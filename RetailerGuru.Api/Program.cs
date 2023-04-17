using RetailerGuru.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using RetailerGuru.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var container = new Container();

// Integrate SimpleInjector
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

container.AddCore(o =>
{
    o.UseInMemoryDBContext = true;  // TODO: Change to live DB later
});

builder.Services.AddControllers();

builder.Services.UseSimpleInjectorAspNetRequestScoping(container);
builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
        .AddControllerActivation();
});

// Add services to the container.
builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// TODO: implement jwt and services
builder.Services.AddAuthentication(options =>
{
    
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
var sp = builder.Services.BuildServiceProvider();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
var apiVersionDescriptionProvider = sp.GetService<IApiVersionDescriptionProvider>();

var assemblyName = typeof(Program).Assembly.GetName().Name;
foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
{
    builder.Services.AddSwaggerDocument(c =>
    {
        c.DefaultResponseReferenceTypeNullHandling = NJsonSchema.Generation.ReferenceTypeNullHandling.Null;
        c.Title = $"{assemblyName} API";
        c.DocumentName = description.GroupName;
        c.Version = description.ApiVersion.ToString();
        c.ApiGroupNames = new[] { description.GroupName };

        if (description.IsDeprecated)
        {
            c.Description = "This API version has been deprecated.";
        }
        //c.GenerateXmlObjects = true;
        c.SchemaNameGenerator = new FullSchemaNameGenerator();
    });
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(c =>
    {
        c.DocExpansion = "list";
        var assemblyName = typeof(Program).Assembly.GetName().Name;
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.OrderByDescending(d => d.ApiVersion))
        {
            c.SwaggerRoutes.Add(new NSwag.AspNetCore.SwaggerUi3Route($"{assemblyName} - {description.GroupName.ToUpperInvariant()}", $"/swagger/{description.GroupName}/swagger.json"));
        }
    });
}

app.UseCors("EnableCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
