using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Context;
using MinimalWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Context>
    (options => options.UseSqlServer("Server=WELIN\\SQL2019,1433;Database=MinimalApi;User Id=sa;Password=medsys;"));

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();

app.MapGet("GetListDoctors", async (Context context) =>
{
    return await context.Doctor.ToListAsync();
});

app.MapGet("GetDoctor/{id}", async (int id, Context context) =>
{
    return await context.Doctor.FirstOrDefaultAsync(d => d.Id == id);
    
});

app.MapPost("IncludeDoctor", async (Doctor doctor, Context context) =>
{
    context.Doctor.Add(doctor);
    await context.SaveChangesAsync();
});

app.MapDelete("DeleteDoctor/{id}", async (int id, Context context) =>
{
    var doctor = await context.Doctor.FirstOrDefaultAsync(d => d.Id == id);
    if(doctor != null)
    {
       context.Doctor.Remove(doctor);
       await context.SaveChangesAsync();
    }
});

app.UseSwaggerUI();
app.Run();
