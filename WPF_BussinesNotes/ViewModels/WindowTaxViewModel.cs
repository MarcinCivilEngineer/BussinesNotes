using Caliburn.Micro;
using System.Linq;
using System.Windows;
using WPF_BussinesNotes.ViewModels;
using WPF_BussinesNotesLibrary;
using WPF_BussinesNotesLibrary.Models;

namespace WPF_BussinesNotes.ViewModels
{
    public class WindowTaxViewModel : Conductor<object>
    {
        private ShellViewModel OknoProjektu = (ShellViewModel)Application.Current.MainWindow.DataContext;
        private SqlLiteDataAcces da = new SqlLiteDataAcces();

        //public ShellViewModel OknoProjektu;

        private TaxModel _eD = new TaxModel();

        public TaxModel Ed
        {
            get { return _eD; }
            set
            {
                _eD = value;

            }
        }


        public WindowTaxViewModel()
        {
            if (da.LoadTax(id: 1).Count()>0) {
                Ed = da.LoadTax(id: 1).First();
            }
            else { 

            Ed.ValueOfTaxReduction = 556.02;
            Ed.TaxThreshold1precent = 17;
            Ed.TaxThreshold1value = 85528;
            Ed.TaxThreshold2precent = 32;
            Ed.TaxThreshold2value = 0;
            Ed.TaxThreshold3precent = 0;
            Ed.LocalWorker = 111.25;
            Ed.CommuterWorker = 139.06;
            Ed.TaxAdvance = 18;
            Ed.TaxDeductibleExpenses = 20;
            Ed.PensionablePay = 19.52;
            Ed.SocialPensionContribution = 8;
            Ed.SocialPensionContributionWorker = 1.5;
            Ed.SickPay = 2.45;
            Ed.Resultant = 1.8;
            Ed.LabourFund = 2.45;
            Ed.Funds = 0.1;
            Ed.HealthInsurance = 9;
            Ed.PartUndeductFromTax = 1.25;
            }
            NotifyOfPropertyChange(() => Ed);
        }

        public void CreateButton(string edNazwaZlecenia)
        {
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
        public void UpdateButton()
        {
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

