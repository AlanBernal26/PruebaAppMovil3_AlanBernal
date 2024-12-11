using Firebase.Database;
using PruebaAppMovil.Modelos.Modelos;
using System.Collections.ObjectModel;
namespace PruebaAppMovil.AppMovil.Vistas;

public partial class ListarEstudiantes : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://db-estudiantes-4d120-default-rtdb.firebaseio.com/");
    public ObservableCollection<Estudiantes> Lista { get; set; } = new ObservableCollection<Estudiantes>();
    public object ListaCollection { get; private set; }

    public ListarEstudiantes()
	{
        InitializeComponent();
        BindingContext = this;
        CargarLista();
	}

    private void CargarLista()
    {
        client.Child("Estudiantes").AsObservable<Estudiantes>().Subscribe((Estudiantes) =>
        { 
            if (Estudiantes != null)
            {
                Lista.Add(Estudiantes.Object);
            }
        });
    }

    private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = filtroSearchBar.Text.ToLower();

        if(filtro.Length > 0)
        {
            listaCollection.ItemsSource = Lista.Where(x => x.NombreCompleto.ToLower().Contains(filtro));
        }
        else
        {
            listaCollection.ItemsSource = Lista;
        }
    }

    private async void NuevoEstudianteBoton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearEstudiantes());
    }
}