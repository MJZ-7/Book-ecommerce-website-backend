using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using sda_onsite_2_csharp_backend_teamwork_The_countryside_developers;
using sda_onsite_2_csharp_backend_teamwork_The_countryside_developers.src.Middlewares;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly); // Add Mapper in build 

// configuring DB
var _config = builder.Configuration;
var dataSourceBuilder = new NpgsqlDataSourceBuilder(@$"Host={_config["Db_Host"]};Username={_config["Db_Username"]};Database={_config["Db_Database"]};Password={_config["Db_Password"]}");
dataSourceBuilder.MapEnum<Role>();
dataSourceBuilder.MapEnum<Status>();

var dataSource = dataSourceBuilder.Build();
builder.Services.AddDbContext<DatabaseContext>((options) =>
{
    options.UseNpgsql(dataSource).UseSnakeCaseNamingConvention();
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);




builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly); // Add Mapper in build 


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding injections in Container
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductService, productService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<CustomErrorMiddleware>();

var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
builder.Services.AddCors(Options =>
{
    Options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins(builder.Configuration["Cors:Origin"]!)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((host) => true)
                            .AllowCredentials();

    });
});

builder.Services.AddSwaggerGen(
     options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Bearer token authentication",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "Bearer"
        }
        );

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    }
);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt_Issuer"],
            ValidAudience = builder.Configuration["Jwt_Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt_SigningKey"]!))
        };
    });


var app = builder.Build();
// Error Handling Middleware:
app.UseMiddleware<CustomErrorMiddleware>();

app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
// Middlewares:
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.Run();