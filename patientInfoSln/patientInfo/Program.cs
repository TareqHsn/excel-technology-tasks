using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Repositories.AllergiesDetailsRepository;
using patientInfo.Repositories.AllergyRepository;
using patientInfo.Repositories.DiseaseRepository;
using patientInfo.Repositories.NCD_DetailsRepository;
using patientInfo.Repositories.NCDRepository;
using patientInfo.Repositories.PatientRepository;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder.Services.AddScoped<IDiseaseRepository, DiseaseRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAllergies_DetailsRepository, Allergies_DetailsRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<INCDRepository, NCDRepository>();
builder.Services.AddScoped<INCD_DetailsRepository, NCD_DetailsRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
