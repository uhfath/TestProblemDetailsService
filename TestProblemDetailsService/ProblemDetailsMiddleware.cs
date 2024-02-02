using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace TestProblemDetailsService
{
	public class ProblemDetailsMiddleware
	{
		private readonly RequestDelegate _nextDelegate;

		public ProblemDetailsMiddleware(
			RequestDelegate nextDelegate)
		{
			this._nextDelegate = nextDelegate;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _nextDelegate(httpContext);
			}
			catch (ValidationException validationException)
			{
				var problemDetails = httpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>().CreateValidationProblemDetails(httpContext, validationException.ModelStateDictionary);
				httpContext.Response.StatusCode = problemDetails.Status.Value;

				await httpContext.RequestServices.GetRequiredService<IProblemDetailsService>().WriteAsync(new ProblemDetailsContext
				{
					HttpContext = httpContext,
					ProblemDetails = problemDetails,
				});
			}
		}
	}
}
