using Firebase.Database;
using Firebase.Database.Query;
using PruebaAppMovil.Modelos.Modelos;
namespace PruebaAppMovil.AppMovil.Vistas;

public partial class CrearEstudiantes : ContentPage
{
	FirebaseClient client = new FirebaseClient("https://db-estudiantes-4d120-default-rtdb.firebaseio.com/");

    public List<Curso> Cursos { get; set; }
	public CrearEstudiantes()
	{
		InitializeComponent();
		ListarCargos();
		BindingContext = this;
	}

    private void ListarCargos()
    {
		var cursos = client.Child("Cursos").OnceAsync<Curso>();
		Cursos=cursos.Result.Select(x =>x.Object).ToList();
	
    }

    private async void guardarButton_Clicked(object sender, EventArgs e)
    {
		Curso curso = cursoPicker.SelectedItem as Curso;
		var estudiante = new Estudiantes
		{
			PrimerNombre = primerNombreEntry.Text,
			SegundoNombre = segundoNombreEntry.Text,
			PrimerApellido = primerApellidoEntry.Text,
			SegundoApellido = segundoApellidoEntry.Text,
			CorreoElectronico = correoEntry.Text,
			Edad = int.Parse(edadEntry.Text),
			Curso = curso
		};
		try
		{
			await client.Child("Estudiantes").PostAsync(estudiante);
            await DisplayAlert("Éxito", $"El estudiante {estudiante.PrimerNombre} {estudiante.PrimerApellido} fue guardado correctamente", "OK");
            await Navigation.PopAsync();
        }
		catch (Exception ex)
		{
			await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}