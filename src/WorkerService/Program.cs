using Application.Common.Interfaces;
using Application.Services;
using Domain;
using Domain.Exercise1;
using WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<MockDataService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IPasswordUpdateService, PasswordUpdateService>();

var host = builder.Build();
host.Run();
