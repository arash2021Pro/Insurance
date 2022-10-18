using CoreStorage.StorageContext;
using ElmahCore.Mvc;
using Hangfire;
using HappyInsurance.BlazorCoreModules.BindCoreServices;
using HappyInsurance.BlazorCoreModules.CoreApplication;
using HappyInsurance.BlazorCoreModules.CoreAuthenticationService;
using HappyInsurance.BlazorCoreModules.CoreHangfireService;
using HappyInsurance.BlazorCoreModules.CoreSqlserverInitialization;
using HappyInsurance.BlazorCoreModules.ElmahCore;
using HappyInsurance.BlazorCoreModules.SqlStorage;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.SetSqlServerService(builder.Configuration);
builder.Services.SetCoreAppService();
builder.Services.SetElmahService(builder.Configuration);
builder.Services.SetHangfireService(builder.Configuration);
builder.Services.SetBindService(builder.Configuration);
builder.Services.AddResponseCompression(x=>x.EnableForHttps = true);
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.SetDatabaseInitialScopeService();
app.UseHttpsRedirection();
app.UseHangfireDashboard();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseElmah();

app.Run();