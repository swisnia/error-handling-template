
using ErrorHandligTemplate.ErrorHandling;
using ErrorHandligTemplate.ErrorHandling.Handlers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*********************************************************************/

//Adding service
builder.Services.AddSingleton<IExceptionHandler, ExceptionHandler>();

/*********************************************************************/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/**************************************************************/

// Adding Exception handling middleware here
app.UseMiddleware<ExceptionHandlerMiddleware>();

/**************************************************************/


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
