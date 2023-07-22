using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.MemberAccounts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//Add Connection String
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AuthorInstitution2023DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add Dependency injection
builder.Services.AddScoped<IMemberAccountRepository, MemberAccountRepository>();

//Add session
builder.Services.AddSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//use session
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
