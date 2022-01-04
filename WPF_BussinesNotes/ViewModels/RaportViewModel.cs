using Caliburn.Micro;
using System.Linq;
using System.Windows;

using WPF_BussinesNotesLibrary;
using WPF_BussinesNotesLibrary.Models;

namespace WPF_BussinesNotes.ViewModels
{
    public class RaportViewModel : Conductor<object>
    {
        private ShellViewModel OknoProjektu = (ShellViewModel)Application.Current.MainWindow.DataContext;
        private SqlLiteDataAcces da = new SqlLiteDataAcces();

        //public ShellViewModel OknoProjektu;

        private TaxModel _ed = new TaxModel();

        public TaxModel Ed
        {
            get { return _ed; }
            set
            {
                _ed = value;

            }
        }


        public RaportViewModel()
        {
            

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

