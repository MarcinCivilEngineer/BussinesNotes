using Caliburn.Micro;
using System.Dynamic;
using System.Linq;
using System.Windows;
using WPF_BussinesNotes.ViewModels;
using WPF_BussinesNotesLibrary;
using WPF_BussinesNotesLibrary.Models;

namespace WPF_BussinesNotes.ViewModels
{
    public class WindowProductsViewModel : Conductor<object>
    {
        private ShellViewModel OknoProjektu = (ShellViewModel)Application.Current.MainWindow.DataContext;
        private SqlLiteDataAcces da = new SqlLiteDataAcces();

        //public ShellViewModel OknoProjektu;

        private BindableCollection<ProductModel> _edGrid = new BindableCollection<ProductModel>();

        public BindableCollection<ProductModel> EdGrid
        {
            get { return _edGrid; }
            set
            {
                _edGrid = value;

            }
        }

        private ProductModel _selectedEdGrid = new ProductModel();

        public ProductModel SelectedEdGrid
        {
            get { return _selectedEdGrid; }
            set
            {
                _selectedEdGrid = value;

            }
        }

        public WindowProductsViewModel()
        {
            EdGrid.AddRange(da.LoadProduct());
            if (EdGrid.Count() > 0) {
                SelectedEdGrid = EdGrid.First();
                    }
            NotifyOfPropertyChange(() => EdGrid);
        }

        public void InsertButton()
        {
            WindowManager windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = "Nowy towar";
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanMinimize;

            var newWindowProductsEdit = new WindowProductsEditViewModel(new ProductModel());
            windowManager.ShowDialogAsync(newWindowProductsEdit);//, null, settings

            EdGrid.Clear();
            EdGrid.AddRange(da.LoadProduct());
            NotifyOfPropertyChange(() => EdGrid);
            

            /*
            //SqlLiteDataAcces da = new SqlLiteDataAcces();
            BudowaModel EditedModel = new BudowaModel { Id = 0, AdresZlecenia = EdAdresZlecenia, IdFirmaWykonawca = SelectedFirmaWykonawca.Id, IdFirmaInwestor = SelectedFirmaInwestor.Id, NazwaZlecenia = EdNazwaZlecenia, NumerZlecenia = EdNumerZlecenia };
            int tmpId = EditedModel.SqlInsert();

            new DokumentacjaTreeModel { Id = 0, IdBudowa = tmpId, IdParent = 0, Nazwa = "ARCHITEKTURA" }.SqlInsert();
            new DokumentacjaTreeModel { Id = 0, IdBudowa = tmpId, IdParent = 0, Nazwa = "KONSTRUKCJA" }.SqlInsert();
            int tmpIdTreeDokumentacji = new DokumentacjaTreeModel { Id = 0, IdBudowa = tmpId, IdParent = 0, Nazwa = "INSTALACJE" }.SqlInsert();
            new DokumentacjaTreeModel { Id = 0, IdBudowa = tmpId, IdParent = tmpIdTreeDokumentacji, Nazwa = "ELEKTROENERGETYCZNE" }.SqlInsert();
            new DokumentacjaTreeModel { Id = 0, IdBudowa = tmpId, IdParent = tmpIdTreeDokumentacji, Nazwa = "SANITARNE" }.SqlInsert();
            new PrzedmiarTabelaModel { Id = 0, IdBudowa = tmpId }.SqlInsert();

            OknoProjektu.Budowa.Clear();
            OknoProjektu.Budowa.AddRange(da.LoadBudowa());
            OknoProjektu.SelectedBudowa = OknoProjektu.Budowa.First(x => x.Id == tmpId);
            NotifyOfPropertyChange(() => OknoProjektu.SelectedBudowa);

            Budowa.Clear();
            Budowa.AddRange(da.LoadBudowa());
            SelectedBudowa = Budowa.First(x => x.Id == tmpId);

            NotifyOfPropertyChange(() => OknoProjektu.Budowa);
            OknoProjektu.SelectedBudowa = OknoProjektu.Budowa.First(x => x.Id == tmpId);
            NotifyOfPropertyChange(() => OknoProjektu.SelectedBudowa);

            MessageBox.Show("Stworzono");
            //NotifyOfPropertyChange(() => ShellViewModel.Projekty);
            */
        }
        public void EditButton()
        {
            WindowManager windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = "Edycja towaru";
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanMinimize;
            int tmpIdProduct = SelectedEdGrid.Id;
            var newWindowProductsEdit = new WindowProductsEditViewModel(SelectedEdGrid);
            windowManager.ShowDialogAsync(newWindowProductsEdit);

            EdGrid.Clear();
            EdGrid.AddRange(da.LoadProduct());
            SelectedEdGrid = EdGrid.First(x => x.Id == tmpIdProduct);
            NotifyOfPropertyChange(() => EdGrid);
            NotifyOfPropertyChange(() => SelectedEdGrid);
            /*
            if (SelectedBudowa != null)
            {
                BudowaModel EditedParametr = new BudowaModel { AdresZlecenia = EdAdresZlecenia, Id = SelectedBudowa.Id, IdFirmaInwestor = SelectedFirmaInwestor.Id, IdFirmaWykonawca = SelectedFirmaWykonawca.Id, NazwaZlecenia = EdNazwaZlecenia, NumerZlecenia = EdNumerZlecenia };
                EditedParametr.SqlQuery();
                Budowa.Clear();
                Budowa.AddRange(da.LoadBudowa());
                OknoProjektu.Budowa.Clear();
                OknoProjektu.Budowa.AddRange(da.LoadBudowa());
                if (OknoProjektu.SelectedBudowa != null)
                {
                    OknoProjektu.SelectedBudowa = OknoProjektu.Budowa.First(x => x.Id == OknoProjektu.SelectedBudowa.Id);
                }
                NotifyOfPropertyChange(() => SelectedBudowa);
                MessageBox.Show("Zmodyfikowano");
            }
            */
        }
        public void VisibilityButton()
        {
        }
        public void CancelButton()
        {
            this.TryCloseAsync(false);
        }

    }
}

