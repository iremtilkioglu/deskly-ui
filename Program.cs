using deskly_ui.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// Uygulama servisleri
builder.Services.AddScoped<CartService>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddScoped<WishlistService>();

// Demo giriş durumu için Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Hata yönetimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTP pipeline
app.UseHttpsRedirection();

app.MapStaticAssets();

app.UseRouting();

// Session, controller işlemlerinden önce çalışmalı
app.UseSession();

app.UseAuthorization();

// Route
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();