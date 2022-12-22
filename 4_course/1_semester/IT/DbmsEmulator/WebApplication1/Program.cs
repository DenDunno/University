using DbmsEmulator.Models.RequestModels;
using DbmsEmulator.Services;
using DbmsEmulator.Validation.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;

#nullable disable

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});
    
builder.Services
   .AddFluentValidationAutoValidation()
   .AddFluentValidationClientsideAdapters();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services
    .AddSingleton<DbmsService>()
    .AddSingleton<AddressService>();

builder.Services
    .AddScoped<IValidator<ColumnInTable>, ColumnInTableValidator>()
    .AddScoped<IValidator<RowInTable>, RowInTableValidator>()
    .AddScoped<IValidator<CellInTable>, CellInTableValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
