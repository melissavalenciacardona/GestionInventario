using AutoMapper;
using LabSoft.AutoMapperPrf;
using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using LabSoft.Data.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = new MapperConfiguration(cfg => {
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton(mapper);  //Inyectar el mapper
builder.Services.AddScoped<IClienteRepository, ClienteRepository>(); 
builder.Services.AddScoped<IClienteRepository, ClienteMysqlRepository>();
builder.Services.AddScoped<IPreferenciaRepository, PreferenciaRepository>();
builder.Services.AddScoped<IDireccionRepository, DireccionRepository>();
builder.Services.AddScoped<IDireccionService, DireccionService>();
builder.Services.AddScoped<IPreferenciaService, PreferenciaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddDbContext<MyDbContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>{
    options.SignIn.RequireConfirmedAccount = false;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<MyDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("*");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();