using Microsoft.EntityFrameworkCore;
using PrintQueueDemo.Data;
using PrintQueueDemo.Models;
using PrintQueueDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=printqueue.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddScoped<PrintJobCostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET all jobs
app.MapGet("/api/jobs", async (AppDbContext db) =>
    await db.PrintJobs.ToListAsync());

// GET job by ID
app.MapGet("/api/jobs/{id}", async (int id, AppDbContext db) =>
    await db.PrintJobs.FindAsync(id) is PrintJob job
        ? Results.Ok(job)
        : Results.NotFound());

// CREATE a new job
app.MapPost("/api/jobs", async (PrintJob job, AppDbContext db) =>
{
    db.PrintJobs.Add(job);
    await db.SaveChangesAsync();
    return Results.Created($"/api/jobs/{job.Id}", job);
});

// COMPLETE a job
app.MapPut("/api/jobs/{id}/complete", async (int id, AppDbContext db) =>
{
    var job = await db.PrintJobs.FindAsync(id);
    if (job is null) return Results.NotFound();

    job.Status = "Done";
    await db.SaveChangesAsync();
    return Results.Ok(job);
});

//Calculate cost
app.MapGet("/api/jobs/{id}/cost", async (int id, AppDbContext db, PrintJobCostService costService) =>
{
    var job = await db.PrintJobs.FindAsync(id);
    if (job is null) return Results.NotFound();

    var config = await db.PricingConfig.SingleAsync();
    var cost = costService.CalculateCost(job, config);

    return Results.Ok(new
    {
        job.Id,
        job.Printer,
        job.ModelName,
        job.FilamentType,
        job.EstimatedMinutes,
        Cost = cost
    });
});

app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.Run();
