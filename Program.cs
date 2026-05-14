using Shop.Data.Interfaces;
using Shop.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICategory, MockCaregory>();
builder.Services.AddTransient<IItem, MockItem>();

builder.Services.AddMvc(op => op.EnableEndpointRouting = false);
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseMvcWithDefaultRoute();
app.Run(); 