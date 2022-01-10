using Caliburn.Micro;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        private string _edCbUnitNewValue;
        public string EdCbUnitNewValue
        {
            get { return _edCbUnitNewValue; }
            set
            {
                _edCbUnitNewValue = value;
            }
        }

        private string _edDoubleValue;
        public string EdDoubleValue
        {
            get { return _edDoubleValue; }
            set
            {
                _edDoubleValue = value;
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

        private ComboBox _edCbUnitValue = new ComboBox();
        public ComboBox EdCbUnitValue
        {
            get { return _edCbUnitValue; }
            set
            {
                _edCbUnitValue = value;
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
        public void GetComboBoxValue(string name)
        {
            EdCbUnitNewValue = name;
        }
        public void SetDoubleValue(string name)
        {
            Ed.Value = double.Parse(name);
        }
        public WindowProductsEditViewModel(ProductModel productModel)
        {
            EdCbUnit.AddRange(da.LoadUnit());
            EdCbProductType.AddRange(da.LoadProductType());
            EdCbVat.AddRange(da.LoadVat());

            //ConventionManager.AddElementConvention<ComboBox>(ComboBox.TextProperty, "Text", "OnKeyDown");
            if (productModel.Id!=0)
            {
                Ed = productModel;
                SelectedEdCbProductType = EdCbProductType.First(x=>x.Id == Ed.ProductType.Id);
                SelectedEdCbUnit = EdCbUnit.First(x=>x.Id== Ed.Unit.Id);
                SelectedEdCbVat = EdCbVat.First(x=>x.Id==Ed.IdVat);
            }
            else
            {
                Ed.Name = "";
                Ed.PKWiU = "";
                Ed.Value = 0.00;
                Ed.Visable = true;

                if (da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdVat").Count() > 0)
                {
                    Ed.IdVat = int.Parse(da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdVat").First().Value);
                }
                else
                {
                    Ed.IdVat = EdCbVat.First().Id;
                }

                if (da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdUnit").Count() > 0)
                {
                    Ed.IdUnit = int.Parse(da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdUnit").First().Value);
                }
                else
                {
                    Ed.IdUnit = EdCbUnit.First().Id;
                }

                if (da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdProductType").Count() > 0)
                {
                    Ed.IdProductType = int.Parse(da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdProductType").First().Value);
                }
                else
                {
                    Ed.IdProductType = EdCbProductType.First().Id;
                }

                SelectedEdCbProductType = EdCbProductType.First(x=>x.Id==Ed.IdProductType);
                SelectedEdCbUnit = EdCbUnit.First(x => x.Id == Ed.IdUnit);
                SelectedEdCbVat = EdCbVat.First(x => x.Id == Ed.IdVat);
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
            Ed.IdVat = SelectedEdCbVat.Id;
            if (SelectedEdCbUnit!=null) { 
                Ed.IdUnit = SelectedEdCbUnit.Id;
            } else
            {
                int tmpIdUnit = new UnitModel() { Id = 0, Name = EdCbUnitNewValue }.SqlInsert();
                Ed.IdUnit = tmpIdUnit;
            }
            Ed.IdProductType = SelectedEdCbProductType.Id;
            if (Ed.Id == 0)
            {
                Ed.SqlInsert();
                if (da.LoadProgramDefaultSetup("WindowProductsEditViewModel_IdVat").Count() > 0)
                {
                    new ProgramDefaultSetupModel() { Id = da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdVat").First().Id, Name = "WindowProductsEditViewModel_IdVat", Value = Ed.IdVat.ToString() }.SqlUpdate();
                }
                else
                {
                    new ProgramDefaultSetupModel() { Id = 0, Name = "WindowProductsEditViewModel_IdVat", Value = SelectedEdCbVat.Id.ToString() }.SqlInsert();
                }

                if (da.LoadProgramDefaultSetup("WindowProductsEditViewModel_IdUnit").Count() > 0)
                {
                    new ProgramDefaultSetupModel() { Id = da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdUnit").First().Id, Name = "WindowProductsEditViewModel_IdUnit", Value = Ed.IdUnit.ToString() }.SqlUpdate();
                }
                else
                {
                    new ProgramDefaultSetupModel() { Id = 0, Name = "WindowProductsEditViewModel_IdUnit", Value = SelectedEdCbUnit.Id.ToString() }.SqlInsert();
                }

                if (da.LoadProgramDefaultSetup("WindowProductsEditViewModel_IdProductType").Count() > 0)
                {
                    new ProgramDefaultSetupModel() { Id = da.LoadProgramDefaultSetup(parametr: "WindowProductsEditViewModel_IdProductType").First().Id, Name = "WindowProductsEditViewModel_IdProductType", Value = Ed.IdProductType.ToString() }.SqlUpdate();
                }
                else
                {
                    new ProgramDefaultSetupModel() { Id = 0, Name = "WindowProductsEditViewModel_IdProductType", Value = SelectedEdCbProductType.Id.ToString() }.SqlInsert();
                }
            } else
            {
                Ed.SqlUpdate();
            }
            this.TryCloseAsync(false);
        }
        public void CancelButton()
        {
            this.TryCloseAsync(false);
        }

    }
}

