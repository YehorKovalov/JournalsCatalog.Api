using JournalCatalog.Api.Data;
using JournalCatalog.Api.Services;
using JournalCatalog.Api.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.WriteIndented = true);
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JournalsStore>();
builder.Services.AddScoped<IJournalService, JournalService>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();