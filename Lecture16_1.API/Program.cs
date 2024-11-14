using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Repo;
using Lecture16_1.Core.Services;
using Microsoft.AspNetCore.Hosting.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string serverPath = "Server=localhost;Database=Lecture16;Trusted_Connection=True;TrustServerCertificate=true;";

IClientRepo clientRepo = new ClientRepo(serverPath);
IClientService clientService = new ClientService(clientRepo);
builder.Services.AddTransient<IClientRepo, ClientRepo>(x => new ClientRepo(serverPath));
builder.Services.AddTransient<IClientService, ClientService>();

IRentalRepo rentalRepo = new RentalRepo(serverPath);
IRentalService rentalService = new RentalService(rentalRepo);
builder.Services.AddTransient<IRentalRepo, RentalRepo>(x => new RentalRepo(serverPath));
builder.Services.AddTransient<IRentalService, RentalService>();

IWorkerRepo workerRepo = new WorkerRepo(serverPath);
IWorkerService workerService = new WorkerService(workerRepo);
builder.Services.AddTransient<IWorkerRepo, WorkerRepo>(x => new WorkerRepo(serverPath));
builder.Services.AddTransient<IWorkerService, WorkerService>();

ICarRepo carRepo = new CarRepo(serverPath);
ICarService carService = new CarService(carRepo, rentalRepo);
builder.Services.AddTransient<ICarRepo, CarRepo>(x => new CarRepo(serverPath));
builder.Services.AddTransient<ICarService, CarService>();



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

app.Run();
