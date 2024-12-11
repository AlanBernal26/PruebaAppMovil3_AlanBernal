using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Extensions.Logging;
using PruebaAppMovil.Modelos.Modelos;
using System.Security.Cryptography.X509Certificates;

namespace PruebaAppMovil.AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
            Registrar();
#endif

            return builder.Build();

            
        }

        public static void Registrar()
        {
            FirebaseClient client = new FirebaseClient("https://db-estudiantes-4d120-default-rtdb.firebaseio.com/");

            var cursos = client.Child("Cursos").OnceAsync<Curso>();

            if (cursos.Result.Count==0)
            {
                client.Child("Cursos").PostAsync(new Curso { Nombre = "Primero Medio" });
                client.Child("Cursos").PostAsync(new Curso { Nombre = "Segundo Medio" });
                client.Child("Cursos").PostAsync(new Curso { Nombre = "Tercero Medio" });
                client.Child("Cursos").PostAsync(new Curso { Nombre = "Cuarto Medio" });
            }
        }
    }
}
