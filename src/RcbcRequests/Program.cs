using RcbcRequests.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Connection string (env var overrides appsettings.json)
var connStr = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddSingleton(new Sql(connStr));
builder.Services.AddScoped<RequestsRepository>();
builder.Services.AddScoped<UsersRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
