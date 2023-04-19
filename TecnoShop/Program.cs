using Microsoft.EntityFrameworkCore;
using TecnoShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agregar servicio
builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();


//Agregar como servicio al dbcontext
builder.Services.AddDbContext<TecnoShopDbContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Conexion"]);
});


//Agregar servicio de RazorRuntimeCompilation
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

//antes de lanzar la aplicacion va ejecutar este metodo
DbInitializer.Seed(app);
app.Run();
