using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using DAL;
using Model;
using Model.Common;
using Repository;
using Repository.Common;
using Service;
using Service.Common;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(
    builder =>
    {     
        builder.RegisterType<Model.VehicleModel>().As<IVehicleModel>();
        builder.RegisterType<Model.VehicleMake>().As<IVehicleMake>();
        builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
        builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
        builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
        builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();
        builder.RegisterType<VehicleMakeRepository>().As<IGenericRepository<DAL.VehicleMake>>();
        builder.RegisterType<VehicleModelRepository>().As<IGenericRepository<DAL.VehicleModel>>();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        builder.RegisterType<VehicleContext>();
    });
// Add services to the container. 

var config = new MapperConfiguration(c => {
    c.AddProfile<VehicleMakeProfile>();
    c.AddProfile<VehicleModelProfile>();
});
//
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//
builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VehicleContext>();

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
