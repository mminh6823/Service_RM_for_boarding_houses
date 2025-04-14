using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service_PhongTro.Models;
using Service_PhongTro.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Thêm Swagger vào services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PhongTroService API",
        Version = "v1",
        Description = "API_phong_tro"
    });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<DayTroService>();
builder.Services.AddTransient<DichVuService>();
builder.Services.AddTransient<DichVuSuDungService>();
builder.Services.AddTransient<DienNuocService>();
builder.Services.AddTransient<LoaiPhongService>();
builder.Services.AddTransient<PhongService>();
builder.Services.AddTransient<TaiKhoanNguoiDungService>();
builder.Services.AddTransient<TaiKhoanService>();
builder.Services.AddTransient<ThongBaoService>();
builder.Services.AddTransient<ThuePhongService>();
builder.Services.AddTransient<NguoiThueService>();
builder.Services.AddTransient<HoaDonService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });



var app = builder.Build();

// Chỉ bật Swagger nếu chạy trên Development HOẶC có biến môi trường ALLOW_SWAGGER
if (app.Environment.IsDevelopment() || builder.Configuration["ALLOW_SWAGGER"] == "true")
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhongTroService API v1");
        c.RoutePrefix = string.Empty; // Truy cập tại root "/"
    });
}


// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
