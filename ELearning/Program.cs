using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ELearning.Data;
using ELearning.Interface;
using ELearning.Services;
using ELearning.Repository;
using AspNetCoreHero.ToastNotification;
using ELearning.Course_Img_Service;
using ELearning.Post_Img_Service;
using ELearning.AppNotify_Img_Service;
using ELearning.API;
using ELearning.SharedFileUpload;
using ELearning_Core.Model.MailSettings;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ELearningContextConnection") ?? throw new InvalidOperationException("Connection string 'ELearningContextConnection' not found.");

builder.Services.AddDbContext<ELearningContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ELearningContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddTransient<IMasterService, MasterService>();
builder.Services.AddTransient<IStudentServiceAPI, StudentServiceAPI>();
builder.Services.AddTransient<IMasterServiceAPI, MasterServiceAPI>();
builder.Services.AddTransient<ICompanyService,CompanyService>();
builder.Services.AddTransient<IFileUplodeService, LocalFileUplodeService>();
builder.Services.AddTransient<IFileUploadSerVice, FileUploadSerVice>();
builder.Services.AddTransient<IFileUpLoadService,FileUpLoadService >();
builder.Services.AddTransient<IBatchServiceAPI,BatchServiceAPI >();
builder.Services.AddTransient<IFileUploadSerVices, FileUploadServices>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddTransient<IFileUploadSerVices, FileUploadServices>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseDatabaseErrorPage();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "Home",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();

