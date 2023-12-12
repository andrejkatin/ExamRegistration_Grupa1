using ExamRegistration_Grupa1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Znaci da cim se napravi objekat ExamRegistrationController-a i inject-uje IExamRegistrationRepository, kreira se jedna instanca objekta klase ExamRegistrationRepository
// Kada se radi sa konkretnom bazom, umesto AddSingleton treba koristiti AddScopped
builder.Services.AddSingleton<IExamRegistrationRepository, ExamRegistrationRepository>();

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

app.Run();
