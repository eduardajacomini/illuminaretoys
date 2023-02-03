using Autofac;
using Autofac.Extensions.DependencyInjection;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Infrastructure.Data.Contexts;
using IlluminareToys.Infrastructure.Data.Seeds;
using IlluminareToys.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using NToastNotify;
using Polly;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder
    .Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddNToastNotifyToastr(new ToastrOptions
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode && r.StatusCode != HttpStatusCode.BadRequest)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(6)
                });

builder.Services.AddHttpClient("Bling", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddPolicyHandler(retryPolicy);

//builder.Services.AddHostedService<SyncProductsWorker>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MainModule()));

var isProduction = Convert.ToBoolean(builder.Configuration["IsProduction"]);

if (isProduction)
{
    builder.WebHost.UseSentry(o =>
    {
        o.Dsn = builder.Configuration["SentryDsn"];
        o.Debug = true;
        o.TracesSampleRate = 1.0;
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}
else
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();
app.UseNToastNotify();

//app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

if (isProduction)
{
    app.UseSentryTracing();
    ExecuteMigrations(app.Services);
}

app.Run();


void ExecuteMigrations(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetRequiredService<AppDbContext>();

    context.Database.Migrate();
}

async Task Seed(WebApplication app)
{
    var services = app.Services.CreateScope().ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
    await IdentitySeed.SeedRolesAsync(userManager, roleManager);
    await IdentitySeed.SeedSuperAdminAsync(userManager, roleManager);
}