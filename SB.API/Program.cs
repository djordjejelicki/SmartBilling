using MediatR;
using Microsoft.EntityFrameworkCore;
using SB.Application.BillItems.Commands.CreateBillItem;
using SB.Application.BillItems.Commands.DeleteBillItem;
using SB.Application.Bills.Commands.CreateBill;
using SB.Application.Bills.Commands.DeleteBill;
using SB.Application.Bills.Queries.GetBillById;
using SB.Application.Contracts;
using SB.Application.DTOs.Bill.Messages;
using SB.Application.DTOs.Bill.Reperesentations;
using SB.Application.DTOs.BillItem.Messages;
using SB.Application.DTOs.BillItem.Representations;
using SB.Data;
using SB.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
//DataBase
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddTransient<IBillRepository, BillRepository>();
builder.Services.AddTransient<IBillItemRepository, BillItemRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));


//Bill
builder.Services.AddTransient<IRequestHandler<CreateBillCommand, BillRepresentation>, CreateBillCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteBillCommand, BillDeletingMessage>, DeleteBillCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetBillByIdQuery, BillRepresentation>, GetBillByIdHandler>();
//BillItem
builder.Services.AddTransient<IRequestHandler<CreateBillItemCommand, BillItemRepresentation>, CreateBillItemCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteBillItemCommand, BillItemDeletingMessage>, DeleteBillItemCommandHandler>();

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
