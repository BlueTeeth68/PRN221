using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<StudentDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Dependency injection                  
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IClassMemberRepository, ClassMemberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Session
builder.Services.AddSession();


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

//use session
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
