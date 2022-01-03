using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Windows;
using WPF_BussinesNotes.Views;
using WPF_BussinesNotesLibrary;


namespace WPF_BussinesNotes.ViewModels
{

    public class ShellViewModel : Conductor<object>
    {



        private string _tytulAplikacji;
        public string TytulAplikacji
        {
            get { return _tytulAplikacji; }
            set
            {
                _tytulAplikacji = value;
            }
        }


        public ShellViewModel()
        {
            //List<ProjektModel> ppp = new List<ProjektModel>();
            //ppp=SqlLiteDataAcces.LoadProjekt();
            //foreach (ProjektModel pp in ppp) {

            //}
            SqlLiteDataAcces da = new SqlLiteDataAcces();
            TytulAplikacji = "Firma";
            //Projekty.Add(new ProjektModel { Id = 1, NumerProjektu = "BET021_21", NazwaProjektu = "Nivea", OpisProjektu = "Takie tam" });
            //Projekty.Add(new ProjektModel { Id = 2, NumerProjektu = "BET024_21", NazwaProjektu = "Lidl", OpisProjektu = "Takie tam mniejsze" });

        }
        public void LoadPageTax()
        {
            WindowManager windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = "Ustawienia podakowe";
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanMinimize;

            var newWindowTax = new WindowTaxViewModel();
            windowManager.ShowDialogAsync(newWindowTax);//, null, settings

        }
        public void LoadPageProducts()
        {
            WindowManager windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = "Towary";
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanMinimize;

            var newWindowProducts = new WindowProductsViewModel();
            windowManager.ShowDialogAsync(newWindowProducts);//, null, settings

        }
        public void LoadPageRaport()
        {
             ActivateItemAsync(new RaportViewModel());
        }

    }

}
