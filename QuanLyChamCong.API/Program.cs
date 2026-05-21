using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Data;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// CONTROLLERS
// ======================================================

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling =
            ReferenceLoopHandling.Ignore;
    });

// ======================================================
// SWAGGER
// ======================================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// ======================================================
// CORS
// ======================================================

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    );
});

// ======================================================
// DATABASE - EF CORE
// ======================================================

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection"
            )
        );
    }
);

// ======================================================
// DATABASE HELPER
// ======================================================

builder.Services.AddScoped<Db>();

// ======================================================
// NHAN VIEN
// ======================================================

builder.Services.AddScoped<NhanVienDAL>();

builder.Services.AddScoped<NhanVienBLL>();

// ======================================================
// CA LAM
// ======================================================

builder.Services.AddScoped<CaLamDAL>();

builder.Services.AddScoped<CaLamBLL>();

// ======================================================
// PHAN CA
// ======================================================

builder.Services.AddScoped<PhanCaDAL>();

builder.Services.AddScoped<PhanCaBLL>();

// ======================================================
// CHAM CONG
// ======================================================

builder.Services.AddScoped<ChamCongDAL>();

builder.Services.AddScoped<ChamCongBLL>();

// ======================================================
// NGHI PHEP
// ======================================================

builder.Services.AddScoped<NghiPhepDAL>();

builder.Services.AddScoped<NghiPhepBLL>();

// ======================================================
// NGHI PHEP NAM
// ======================================================

builder.Services.AddScoped<NghiPhepNamDAL>();

builder.Services.AddScoped<NghiPhepNamBLL>();

// ======================================================
// THUONG PHAT
// ======================================================

builder.Services.AddScoped<ThuongPhatDAL>();

builder.Services.AddScoped<ThuongPhatBLL>();

// ======================================================
// CAU HINH LUONG
// ======================================================

builder.Services.AddScoped<CauHinhLuongDAL>();

builder.Services.AddScoped<CauHinhLuongBLL>();

// ======================================================
// BANG LUONG CHOT
// ======================================================

builder.Services.AddScoped<BangLuongChotDAL>();

builder.Services.AddScoped<BangLuongChotBLL>();

// ======================================================
// QUAN LY CHAM CONG TONG HOP
// ======================================================

builder.Services.AddScoped<QuanLyChamCongDAL>();

builder.Services.AddScoped<QuanLyChamCongBLL>();

// ======================================================
// BUILD APP
// ======================================================

var app = builder.Build();

// ======================================================
// SWAGGER
// ======================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

// ======================================================
// MIDDLEWARE
// ======================================================

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

// ======================================================
// MAP CONTROLLERS
// ======================================================

app.MapControllers();

// ======================================================
// RUN
// ======================================================

app.Run();