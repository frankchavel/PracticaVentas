using AppVentas.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContexto>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBContexto") ?? throw new InvalidOperationException("Cadena de conexión 'BDContexto' no existe.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    //Crear la base de datos
    var servicio = scope.ServiceProvider;//Crea el servicio
    var contexto = servicio.GetRequiredService<DBContexto>();//obtiene el contexto de la base de datos
    contexto.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
