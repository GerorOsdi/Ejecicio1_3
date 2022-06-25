using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ejecicio1_3.Models;
using Ejecicio1_3.View;

namespace Ejecicio1_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtNombres.Text != null && txtApellidos.Text != null && txtEdad.Text != null &&
                    txtCorreo.Text != null && txtDireccion.Text != null)
                {
                    var tmpPersonas = new Personas
                    {
                        Id = 0,
                        Nombres = txtNombres.Text,
                        Apellidos = txtApellidos.Text,
                        Direccion = txtDireccion.Text,
                        Correo = txtCorreo.Text,
                        Edad = int.Parse(txtEdad.Text)
                    };

                    var rest = await App.DbPersonas.savePersonas(tmpPersonas);

                    if (rest > 0)
                    {
                        await DisplayAlert("Notificacion", "Dato Guardado con Exito", "Aceptar");
                        limpiar();
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Dato no se pudo almacenar", "Aceptar");
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


        private void limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new lstPersonas());
        }
    }
}
