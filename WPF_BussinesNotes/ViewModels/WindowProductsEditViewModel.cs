using Caliburn.Micro;
using System.Linq;
using System.Windows;
using WPF_BussinesNotes.ViewModels;
using WPF_BussinesNotesLibrary;
using WPF_BussinesNotesLibrary.Models;

namespace WPF_BussinesNotes.ViewModels
{
    public class WindowProductsEditViewModel : Conductor<object>
    {
        private ShellViewModel OknoProjektu = (ShellViewModel)Application.Current.MainWindow.DataContext;
        private SqlLiteDataAcces da = new SqlLiteDataAcces();

        //public ShellViewModel OknoProjektu;

        private ProductModel _ed = new ProductModel();
        public ProductModel Ed
        {
            get { return _ed; }
            set
            {
                _ed = value;
                NotifyOfPropertyChange(() => Ed);
            }
        }



        private BindableCollection<UnitModel> _edCbUnit = new BindableCollection<UnitModel>();
        public BindableCollection<UnitModel> EdCbUnit
        {
            get { return _edCbUnit; }
            set
            {
                _edCbUnit = value;
            }
        }


        private BindableCollection<ProductTypeModel> _edCbProductType = new BindableCollection<ProductTypeModel>();
        public BindableCollection<ProductTypeModel> EdCbProductType
        {
            get { return _edCbProductType; }
            set
            {
                _edCbProductType = value;
            }
        }

        private BindableCollection<VatModel> _edCbVat = new BindableCollection<VatModel>();
        public BindableCollection<VatModel> EdCbVat
        {
            get { return _edCbVat; }
            set
            {
                _edCbVat = value;
            }
        }

        private ProductTypeModel _selectedEdCbProductType = new ProductTypeModel();
        public ProductTypeModel SelectedEdCbProductType
        {
            get { return _selectedEdCbProductType; }
            set
            {
                _selectedEdCbProductType = value;
            }
        }

        private VatModel _selectedEdCbVat = new VatModel();
        public VatModel SelectedEdCbVat
        {
            get { return _selectedEdCbVat; }
            set
            {
                _selectedEdCbVat = value;
            }
        }

        private UnitModel _selectedEdCbUnit = new UnitModel();
        public UnitModel SelectedEdCbUnit
        {
            get { return _selectedEdCbUnit; }
            set
            {
                _selectedEdCbUnit = value;
            }
        }
        public WindowProductsEditViewModel(ProductModel productModel)
        {
            EdCbUnit.AddRange(da.LoadUnit());
            EdCbProductType.AddRange(da.LoadProductType());
            EdCbVat.AddRange(da.LoadVat());
            if (productModel.Id!=0)
            {
                Ed = productModel;
                SelectedEdCbProductType = Ed.ProductType;
                SelectedEdCbUnit = Ed.Unit;
                SelectedEdCbVat = da.LoadVat(wartosc:Ed.Vat).First();
            }
            else
            {
                Ed.Name = "";
                Ed.PKWiU = "";
                Ed.Value = 0;
                Ed.Visable = true;
                Ed.Vat = EdCbVat.First().Value;
                Ed.IdUnit = EdCbUnit.First().Id;
                Ed.IdProductType = EdCbProductType.First().Id;
                SelectedEdCbProductType = EdCbProductType.First();
                SelectedEdCbUnit = EdCbUnit.First();
                SelectedEdCbVat = EdCbVat.First();
            }
            NotifyOfPropertyChange(() => Ed);
            NotifyOfPropertyChange(() => EdCbProductType);
            NotifyOfPropertyChange(() => EdCbUnit);
            NotifyOfPropertyChange(() => EdCbVat);
            NotifyOfPropertyChange(() => SelectedEdCbProductType);
            NotifyOfPropertyChange(() => SelectedEdCbUnit);
            NotifyOfPropertyChange(() => SelectedEdCbVat);
        }

        public void AcceptButton(string edNazwaZlecenia)
        {
            Ed.Vat = SelectedEdCbVat.Value;
            if (EdCbUnit.Where(x => x.Id == SelectedEdCbUnit.Id).Count() > 0) { 
                Ed.IdUnit = SelectedEdCbUnit.Id;
            } else
            {
                // TODO - Create Unit
            }
            Ed.IdProductType = SelectedEdCbProductType.Id;
            if (Ed.Id == 0)
            {
                
                Ed.SqlInsert();
            } else
            {
                Ed.SqlUpdate();
            }
            this.TryCloseAsync(false);
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
        public void CancelButton()
        {
            this.TryCloseAsync(false);
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

    }
}

