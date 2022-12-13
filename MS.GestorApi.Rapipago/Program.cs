using Microsoft.OpenApi.Models;
using MS.Aplicaciones.Rapipago;
using MS.Aplicaciones.Rapipago.Interfaces;
using MS.Dominio.Rapipago.Param;
using MS.Dominio.Rapipago.Request;
using MS.Dominio.Rapipago.Response;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IServicesRapipago<requestbase, UltimaTransaccionResponse, ConfigParameters>, ServicesRapipago>();


builder.Services.AddScoped<IServiciosRapipagoConsultarUltimaOperacion<requestbase, UltimaTransaccionResponse, ConfigParameters>, ServicesRapipago>();
builder.Services.AddScoped<IServiciosRapipagoConfirmarUltimaOperacion<requestConfirmarUltimaOperacion, responseConfirmarUltimaOperacion, ConfigParameters>, ServicesRapipago>();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSerilogServices();
builder.Services.Configure<ConfigParameters>(builder.Configuration.GetSection("ConfigParameters"));

builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Recarga Altamira - Movistar",
        Version = "v1",
        Description = "Permite la comunicacion con los servicios de recargas virtuales mediante la plataforma Altamira...."
    });
    //options.EnableAnnotations();

    //Obtenemos el directorio actual
    var basePath = AppContext.BaseDirectory;
    //Obtenemos el nombre de la dll por medio de reflexión
    var assemblyName = System.Reflection.Assembly
                  .GetEntryAssembly().GetName().Name;
    //Al nombre del assembly le agregamos la extensión xml
    var fileName = System.IO.Path
                  .GetFileName(assemblyName + ".xml");
    //Agregamos el Path, es importante utilizar el comando
    // Path.Combine ya que entre windows y linux 
    // rutas de los archivos
    // En windows es por ejemplo c:/Uusuarios con / 
    // y en linux es \usr con \
    var xmlPath = Path.Combine(basePath, fileName);
    options.IncludeXmlComments(xmlPath);
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5012); // to listen for incoming http connection on port 5001
                               // options.ListenAnyIP(7001, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
