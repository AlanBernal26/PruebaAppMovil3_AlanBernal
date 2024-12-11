using PruebaAppMovil.AppMovil.Vistas;
namespace PruebaAppMovil.AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListarEstudiantes());
        }
    }
}
