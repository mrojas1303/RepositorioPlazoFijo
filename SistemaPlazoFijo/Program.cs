using Microsoft.EntityFrameworkCore;
using SistemaPlazoFijo.Datos;

var builder = WebApplication.CreateBuilder(args);

// Conexión a la Base de Datos

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BaseDeDatos>(options =>
    options.UseSqlServer(@"filename=C:\Databases\PLAZO_FIJO_V2.db")); //Aca especifican la ruta local donde crearon la BD

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Plazos}/{action=Create}/{id?}");

app.Run();
