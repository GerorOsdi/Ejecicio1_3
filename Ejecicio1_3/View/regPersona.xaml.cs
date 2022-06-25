using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejecicio1_3.Models;

namespace Ejecicio1_3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class regPersona : ContentPage
    {
        int ID;
        public regPersona()
        {
            InitializeComponent();
        }

        public regPersona(int id, string nombre, string apellidos, int edad, string correo, string direccion)
        {
            InitializeComponent();
            ID = id;
            txtNombres.Text = nombre;
            txtApellidos.Text = apellidos;
            txtEdad.Text = String.Concat(edad);
            txtCorreo.Text = correo;
            txtDireccion.Text = direccion;
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtNombres.Text != null && txtApellidos.Text != null && txtEdad.Text != null &&
                    txtCorreo.Text != null && txtDireccion.Text != null)
                {
                    var tmpPersonas = new Personas
                    {
                        Id = ID,
                        Nombres = txtNombres.Text,
                        Apellidos = txtApellidos.Text,
                        Direccion = txtDireccion.Text,
                        Correo = txtCorreo.Text,
                        Edad = int.Parse(txtEdad.Text)
                    };

                    var rest = await App.DbPersonas.savePersonas(tmpPersonas);

                    if (rest > 0)
                    {
                        await DisplayAlert("Notificacion", "Dato Actualizado con Exito", "Aceptar");
                        await Navigation.PushAsync(new lstPersonas());
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Dato no se actualizo el registro", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Erro", "Es obligatorio llenar todos los campos", "Aceptar");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}