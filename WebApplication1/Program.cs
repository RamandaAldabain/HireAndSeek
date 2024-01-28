using HireAndSeek.Data;
using Microsoft.EntityFrameworkCore;
using HireAndSeek.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static HireAndSeek.Entities.ValidationHelpers.AppointmentHourRange;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);
//var key = "Qweras778992**__))(()()(5d";
var key1 = Encoding.UTF8.GetBytes("Qweras778992**__))(()(iiiiiii8)(5d")
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
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<FileService>();
builder.Services.AddScoped<SkillsService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddTransient<JwtAuthenticationManager>(provider =>
{
	// Resolve dependencies within the factory method
	var dbContext = provider.GetRequiredService<DatabaseContext>();
	var fileService = provider.GetRequiredService<FileService>();
	var skillsService = provider.GetRequiredService<SkillsService>();
	var accountManagerService = new AccountService(dbContext,fileService,skillsService, builder.Configuration);

	return new JwtAuthenticationManager(key, accountManagerService);
});// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var validHours=builder.Configuration.GetSection("SkillLimitConfig:AppointmentHours").Get<int[]>();
ValidateHourRange.InitializeValidHours(builder.Configuration);
builder.Services.AddDbContext<DatabaseContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
//builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DatabaseContext>();




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
