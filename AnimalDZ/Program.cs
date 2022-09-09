using AnimalDZ.Model;
using AnimalDZ.Repositories;
using AnimalDZ.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<Animal, Cat>();
builder.Services.AddTransient<Animal, Dog>();
builder.Services.AddTransient<IFileOperations, FileOperations>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
