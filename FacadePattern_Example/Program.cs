using FacadePattern_Example;
using FacadePattern_Example.Endpoints;
using FacadePattern_Example.Services;
using FacadePattern_Example.Services.FascadeServices;

var builder = WebApplication.CreateBuilder(args);


// FakeDb
var fakeDb = new FakeDB();

#region Register services
//Register Db
builder.Services.AddSingleton<FakeDB>(fakeDb);

//Register Other Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<OrderService>();

// Register OrderFacade
builder.Services.AddScoped<OrderFacade>();
#endregion

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

//With Facade Pattern 
app.MapFacadeEndPoints();

//WithOut FacadePattern
app.MapWithoutFacadeEndPoints();

app.Run();
