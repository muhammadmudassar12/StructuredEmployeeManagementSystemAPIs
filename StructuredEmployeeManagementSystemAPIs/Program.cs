using EmployManagementSystemAPIs.Services.BasicInfoServices;
using EmployManagementSystemAPIs.Services.EmgContactInfoServices;
using EmployManagementSystemAPIs.Services.HolidayInfoServices;
using EmployManagementSystemAPIs.Services.SalaryInfoServices;
using StructuredEmployeeManagementSystemAPIs.Connection;
using StructuredEmployeeManagementSystemAPIs.Repositories.BasicInfoRepository;
using StructuredEmployeeManagementSystemAPIs.Repositories.EmgContactInfoRepository;
using StructuredEmployeeManagementSystemAPIs.Repositories.HolidayInfoRepository;
using StructuredEmployeeManagementSystemAPIs.Repositories.SalaryInfoRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBasicInfoServices, BasicInfoServices>();
builder.Services.AddTransient<IEmgContactInfoServices, EmgContactInfoServices>();
builder.Services.AddTransient<ISalaryInfoServices, SalaryInfoServices>();
builder.Services.AddTransient<IHolidayInfoServices, HolidayInfoServices>();
//Add Repositories to the container.
builder.Services.AddTransient<IBasicInfoRepository, BasicInfoRepository>();
builder.Services.AddTransient<IEmgContactInfoRepository, EmgContactInfoRepository>();
builder.Services.AddTransient<ISalaryInfoRepository, SalaryInfoRepository>();
builder.Services.AddTransient<IHolidayInfoRepository, HolidayInfoRepository>();
//Add Connection to the container.
builder.Services.AddTransient<IConnectionString, ConnectionString>();

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
