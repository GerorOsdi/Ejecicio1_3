using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejecicio1_3.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejecicio1_3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lstPersonas : ContentPage
    {
        public lstPersonas()
        {
            InitializeComponent();
        }

        private async void viewPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                Personas itemSelc = e.CurrentSelection[0] as Personas;

               string rest = await DisplayActionSheet("Aviso", "Que quiere realizar con el registro seleccionado", null,"Actualizar", "Eliminar");
                Debug.WriteLine("action:" + rest);

                if (rest == "Actualizar")
                {
                    await Navigation.PushAsync(new View.regPersona(itemSelc.Id,itemSelc.Nombres, itemSelc.Apellidos, itemSelc.Edad, itemSelc.Correo, itemSelc.Direccion));
                }
                else if(rest == "Eliminar")
                {
                    await App.DbPersonas.PersonaDelete(itemSelc);
                    viewPersonas.ItemsSource = await App.DbPersonas.getPersonas();
                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            viewPersonas.ItemsSource = await App.DbPersonas.getPersonas();
        }
    }
}