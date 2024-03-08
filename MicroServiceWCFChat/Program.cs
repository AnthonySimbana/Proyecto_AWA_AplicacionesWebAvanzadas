
using Google.Cloud.Firestore;

namespace ExamenWebAnthony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Connection FireStore
            builder.Services.AddSingleton(provider =>
            {
                // Proporcionar los parámetros necesarios para la construcción de FirestoreDb
                string projectId = "webaplicationanthony";
                string jsonPath = "configurationfirebase.json"; // Ruta al archivo JSON de credenciales
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", jsonPath);

                // Construir y devolver una instancia de FirestoreDb
                FirestoreDbBuilder builder = new FirestoreDbBuilder
                {
                    ProjectId = projectId
                };
                var db = builder.Build();
                return db;
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
