using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class GlobalExceptionHandler
{
	private readonly RequestDelegate _delegate;
	private readonly ILogger _logger;

	public GlobalExceptionHandler(RequestDelegate requestDelegate) => _delegate = requestDelegate;

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _delegate(context);
		}
        
		catch (NoChangesException ex)
		{
            context.Response.StatusCode = 500;
			var response = "Nessun cambiamento nel database";
			await context.Response.WriteAsync(response);
        }

        catch (DbUpdateException ex)
        {
			context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            var response = "I dati inseriti sono già esistenti";
            await context.Response.WriteAsync(response);
        }

        catch (Exception e)
		{
			Console.Error.WriteLine(e);
			context.Response.StatusCode = 500;
            var response = "Errore 500 generico";
            await context.Response.WriteAsync(response);
        }

	}
}
