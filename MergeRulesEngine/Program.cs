using MergeRulesEngine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IMergeRulesRepository, MergeRulesRepository>();
builder.Services.AddTransient<IMergeRulesService, MergeRulesService>();
builder.Services.AddKeyedTransient<IRule, AgeRule>(RuleEnum.AgeRule);
builder.Services.AddKeyedTransient<IRule, SurnameRule>(RuleEnum.SurnameRule);

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
