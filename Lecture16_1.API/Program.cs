using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.ISave;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Repo;
using Lecture16_1.Core.RepoMongo;
using Lecture16_1.Core.Services;
using Lecture16_1.Core.Utils.CreateBackup;
using Microsoft.AspNetCore.Hosting.Server;
using MongoDB.Driver;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));

string serverPath = "Server=localhost;Database=Lecture16;Trusted_Connection=True;TrustServerCertificate=true;";

builder.Services.AddTransient<IClientRepo, ClientRepo>(x => new ClientRepo(serverPath));
builder.Services.AddTransient<IClientService, ClientService>();

builder.Services.AddTransient<IRentalRepo, RentalRepo>(x => new RentalRepo(serverPath));
builder.Services.AddTransient<IRentalService, RentalService>();

builder.Services.AddTransient<IWorkerRepo, WorkerRepo>(x => new WorkerRepo(serverPath));
builder.Services.AddTransient<IWorkerService, WorkerService>();

//builder.Services.AddTransient<ICarRepo, CarRepo>(x => new CarRepo(serverPath));
builder.Services.AddTransient<ICarRepo, CarRepoNew>();
builder.Services.AddTransient<ICarService, CarService>();

builder.Services.AddTransient<ISaveClients, SaveClients>(x => new SaveClients("Clients.txt"));
builder.Services.AddTransient<ISaveElectricCars, SaveElectricCars>(x => new SaveElectricCars("ElectricCars.txt"));
builder.Services.AddTransient<ISavePetrolCars, SavePetrolCars>(x => new SavePetrolCars("PetrolCars.txt"));
builder.Services.AddTransient<ISaveRentals, SaveRentals>(x => new SaveRentals("Rentals.txt"));
builder.Services.AddTransient<ISaveWorkers, SaveWorkers>(x => new SaveWorkers("Workers.txt"));
builder.Services.AddTransient<ISaveService, SaveService>();
builder.Services.AddTransient<IReceiptRepo, ReceiptRepo>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var log = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/CarRentalLog.txt", rollingInterval: RollingInterval.Day).CreateLogger();
Log.Logger = log;

app.Run();
