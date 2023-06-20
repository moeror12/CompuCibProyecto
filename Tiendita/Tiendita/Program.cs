using Tiendita.Controllers;
using Tiendita.IServices;
using Tiendita.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddSqlServer("Data Source=DESKTOP-M88DDL1;Initial Catalog=tiendita;user id=sa; password=david1");
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ProductoController>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<CategoriaController>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<VentaController>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ClienteController>();
builder.Services.AddScoped<IContactoService, ContactoService>();
builder.Services.AddScoped<ContactoService>();
builder.Services.AddScoped<IOrdenService, OrdenService>();
builder.Services.AddScoped<OrdenService>();
builder.Services.AddScoped<IDetalleOrdenService, DetalleOrdenService>();
builder.Services.AddScoped<DetalleOrdenService>();
builder.Services.AddScoped<IReclamoService, ReclamoService>();
builder.Services.AddScoped<ReclamoService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("_", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("_");
app.UseAuthorization();

app.MapControllers();

app.Run();
