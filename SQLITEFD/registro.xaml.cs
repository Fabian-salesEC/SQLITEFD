using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLITEFD.Models;

namespace SQLITEFD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Clave = txtClave.Text };
                _conn.InsertAsync(Registros);
                limpiarFormulario();
                
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
        void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtClave.Text = "";
            txtUsuario.Text = "";
            DisplayAlert("Alerta", "Dato ingresado", "OK");
        }
    }
}