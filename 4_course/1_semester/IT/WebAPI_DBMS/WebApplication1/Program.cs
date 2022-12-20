using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Services;
using DbmsEmulator.Validation;
using FluentValidation;

#nullable disable

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbmsService>(sp => new(new List<Database>()));
builder.Services.AddScoped<IValidator<Table>, TableValidator>();
builder.Services.AddScoped<IValidator<Column>, ColumnValidator>();
builder.Services.AddScoped<IValidator<Row>, RowValidator>();
builder.Services.AddScoped<IValidator<Cell>, CellValidator>();

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
