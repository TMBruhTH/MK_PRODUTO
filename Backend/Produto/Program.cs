using AutoMapper;
using DataModel.Context;
using DataModel.Models;
using DataModel.ModelView;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Options;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProdutoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddCors();

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<ProdutoViewModel, Produto>();
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton<IMapper>(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => 
options.WithOrigins("http://localhost:4200").
AllowAnyMethod().
AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
