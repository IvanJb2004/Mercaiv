using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Mercaiv.Servicio;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();//Agrega el acceso a HTTP contex
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IRepositorioProducto, RepositorioProducto>();
builder.Services.AddTransient<IRepositorioContactanos, RepositorioContactanos>();
builder.Services.AddTransient<IRepositorioHome, RepositorioHome>();
builder.Services.AddTransient<IRepositorioNuevaContraseña,RepositorioNuevaContraseña>();
builder.Services.AddTransient<IRepositorioCarrito, RepositorioCarrito>();
builder.Services.AddTransient<IRepositorioProveedor, RepositorioProveedor>();
builder.Services.AddTransient<ProductoSeleccionados>(); // Ensure this line is included
builder.Services.AddTransient<IRepositorioCompra, RepositorioCompra>();
builder.Services.AddTransient<IRepositoriopdfInventario, RepositoriopdfInventario>();
builder.Services.AddTransient<IRepositoriopdfCliente, RepositoriopdfCliente>();
builder.Services.AddTransient<IRepositoriopdfContactanos, RepositoriopdfContactanos>();

builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromSeconds(30);
    Options.Cookie.HttpOnly = true;
    Options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Principal}/{id?}");

app.Run();
