using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.CorrespondingAuthors;
using Repositories.InstitutionInformations;
using Repositories.MemberAccounts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();



//Add Connection String
builder.Services.AddDbContext<AuthorInstitution2023DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add Dependency injection
builder.Services.AddScoped<IMemberAccountRepository, MemberAccountRepository>();
builder.Services.AddScoped<ICorrespondingAuthorRepository, CorrespondingAuthorRepository>();
builder.Services.AddScoped<IInstitutionInformationRepository, InstitutionInformationRepository>();

//Add session
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
