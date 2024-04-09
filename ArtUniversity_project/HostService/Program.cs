using ArtUniversity.Connfiguration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("ArtUniversity_ConnectionString");
ArtUniversityBootStrapper.Configure(builder.Services, connectionString!);
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();