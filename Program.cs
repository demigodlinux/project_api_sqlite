using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using new_project.Data;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<new_projectContext>(options => {options.UseSqlite(builder.Configuration.GetConnectionString("SampleDB"));});



var app = builder.Build();


// Configure the HTTP request pipeline.

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseHsts(); // This enforces HTTPS even in development
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
        app.UseHsts();
    }

    app.UseHsts(); // Use the generated certificate and private key
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "new_projectAPI");
});

app.Use(async (context, next)=> {
    if(context.Request.Path == "/"){
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});

}

app.Run();
