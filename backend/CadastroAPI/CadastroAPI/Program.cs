using CadastroAPI.Repository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "OpenCORSPolicy",
        x =>
        {
            x.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddTransient<IDbConnection>(x =>
    new SqlConnection(builder.Configuration.GetConnectionString("DbConnection"))
);

IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                         .AddJsonFile("appsettings.json")
                                                                         .Build();
builder.Services.AddOptions();
builder.Services.Configure<Config>(configuration.GetSection("Config"));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
builder.Services.AddScoped<IHistoricoRepository, HistoricoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("OpenCORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
