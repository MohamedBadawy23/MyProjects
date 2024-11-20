using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Talapat.core.Entity;
using Talapat.core.Rebosatory;
using Talapat.Reposatory.Data;
using Talapat_Of_Project.Extention;
using Talapat_Of_Project.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextt>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddApplictionService();
//builder.Services.AddAutoMapper(g => g.AddProfile(new MAPPIMG_Profil()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwggerMidleWare();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
