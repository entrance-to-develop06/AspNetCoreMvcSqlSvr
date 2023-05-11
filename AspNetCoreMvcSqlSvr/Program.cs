using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreMvcSqlSvr.Data;
using AspNetCoreMvcSqlSvr.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcShohinContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcShohinContext") ?? throw new InvalidOperationException("接続文字列「MvcShohinContext」が見つかりません。")));

// コンテナにサービスを追加します。
builder.Services.AddControllersWithViews();

var app = builder.Build();

//初期SeedData追加
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// HTTP リクエスト パイプラインを構成します。
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // デフォルトの HSTS 値は 30 日です。運用シナリオではこれを変更することもできます。https://aka.ms/aspnetcore-hsts を参照してください。
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
