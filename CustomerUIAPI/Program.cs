var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Tillader anmodninger fra alle dom�ner
              .AllowAnyMethod()   // Tillader GET, POST, PUT, DELETE osv.
              .AllowAnyHeader();  // Tillader alle HTTP headers
    });
});

// Tilf�j services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["OrderService:MyApiBaseUrl"] ??
    throw new InvalidOperationException("MyApiBaseUrl is missing in configuration"));
   
});

var app = builder.Build();

// Brug CORS overalt i API'et
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
