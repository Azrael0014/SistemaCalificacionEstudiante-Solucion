using SistemaCalificacionEstudiante.Application;
using SistemaCalificacionEstudiante.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.TagActionsBy(api =>
    {
        var controllerName = api.ActionDescriptor.RouteValues["controller"];

        if (controllerName == null)
        {
            return new[] { "Default" };
        }

        switch (controllerName)
        {
            case "Auth":
                return new[] { "1. Auth" };
            case "Students":
                return new[] { "2. Students" };
            case "Materias":
                return new[] { "3. Materias" };
            case "Calificaciones":
                return new[] { "4. Calificaciones" };
            default:
                return new[] { $"5. {controllerName}" };
        }
    });

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Calificaciones API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese 'Bearer' seguido de un espacio y el token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();