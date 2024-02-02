namespace TestProblemDetailsService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddProblemDetails();

			var app = builder.Build();

			app.UseAuthorization();
			app.UseMiddleware<ProblemDetailsMiddleware>();

			app.MapControllers();

			app.Run();
		}
	}
}
