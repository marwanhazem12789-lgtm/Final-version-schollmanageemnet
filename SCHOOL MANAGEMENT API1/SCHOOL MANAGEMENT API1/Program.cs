using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT_API1.AllCustoms.ClassRoomCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.DepartmentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.EnrollmentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.StudentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.SubjectCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.TeacherCustoms;
using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;
using SCHOOL_MANAGEMENT_API1.Unit_Of_Work;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("c")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IGenaricRepo<>), typeof(GenaricRepo<>));

builder.Services.AddScoped<IStudent, StudentCustom>();
builder.Services.AddScoped<ITeacer, TeacherCustom>();
builder.Services.AddScoped<ISubject, SubjectCustoom>();
builder.Services.AddScoped<IClassroom, ClassroomCustom>();
builder.Services.AddScoped<IDepartment, DepartmentCustom>();
builder.Services.AddScoped<IEnrollment, EnrollmentCustom>();

builder.Services.AddScoped<IUnitOfWork, Unti_Of_Work>();

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
