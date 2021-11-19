using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLITEFD.Models;
using System.IO;

namespace SQLITEFD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class eliminar : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public eliminar(int id)
        {
            _conn = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string clave, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre=?, Usuario=?, " + "Clave=? where id=?", nombre, usuario, clave, id);
        }
        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Clave.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR", ex.Message, "OK");
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "OK");
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", "ERROR", ex.Message,"OK");
            }
        }
    }
}