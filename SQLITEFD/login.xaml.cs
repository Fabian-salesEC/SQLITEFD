using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using SQLITEFD.Models;

namespace SQLITEFD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Models.Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string clave)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Clave=?", usuario, clave);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtClave.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new consulta());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no existe, por favor Registrese", "OK");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK" );
            }
        }

        private async void btnregistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registro());
        }
    }
}