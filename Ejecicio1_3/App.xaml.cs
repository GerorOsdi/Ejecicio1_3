using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejecicio1_3.Controll;
using System.IO;

namespace Ejecicio1_3
{
    public partial class App : Application
    {
        static Transacciones DB;

        public static Transacciones DbPersonas
        {
            get 
            {
                if (DB == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbPersonas.db3");
                    DB = new Transacciones(FolderPath);
                }
                return DB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
