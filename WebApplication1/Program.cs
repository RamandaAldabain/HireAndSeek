using HireAndSeek.Data;
using Microsoft.EntityFrameworkCore;
using HireAndSeek.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
//var key = "Qweras778992**__))(()()(5d";
var key1 = Encoding.UTF8.GetBytes("Qweras778992**__))(()()(5d")
    .Take(32) // Ensure the key is 32 bytes (256 bits)
    .ToArray();

// Convert to Base64-encoded string
var key = Convert.ToBase64String(key1);
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
		ValidateIssuer = false,
		ValidateAudience = false,

	};
});

builder.Services.AddTransient<JwtAuthenticationManager>(provider =>
{
	// Resolve dependencies within the factory method
	var dbContext = provider.GetRequiredService<DatabaseContext>();
	var accountManagerService = new AccountManagerService(dbContext);

	return new JwtAuthenticationManager(key, accountManagerService);
});// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
//builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<AccountManagerService>();
builder.Services.AddScoped<JobService>();

ConfigureMapster.Configure();
var app = builder.Build();

app.UseCors(builder =>
{
	builder.WithOrigins("http://localhost:4200")
		   .AllowCredentials()
		   .AllowAnyMethod()
		   .AllowAnyHeader();
});
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