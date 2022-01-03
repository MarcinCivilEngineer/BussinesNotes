
using System.Collections.Generic;

namespace WPF_BussinesNotesLibrary.Models
{
    public class TaxModel
    {
        public int Id { get; set; }
        public double ValueOfTaxReduction { get; set; }
        public double TaxThreshold1precent { get; set; }
        public double TaxThreshold1value { get; set; }
        public double TaxThreshold2precent { get; set; }
        public double TaxThreshold2value { get; set; }
        public double TaxThreshold3precent { get; set; }
        public double LocalWorker { get; set; }
        public double CommuterWorker { get; set; }
        public double TaxAdvance { get; set; }
        public double TaxDeductibleExpenses { get; set; }
        public double PensionablePay { get; set; }
        public double SocialPensionContribution { get; set; }
        public double SocialPensionContributionWorker { get; set; }
        public double SickPay { get; set; }
        public double Resultant { get; set; }
        public double LabourFund { get; set; }
        public double Funds { get; set; }
        public double HealthInsurance { get; set; }
        public double PartUndeductFromTax { get; set; }

        ///
        public string tabela = "Tax";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("ValueOfTaxReduction"); list_wartosci.Add(this.ValueOfTaxReduction.ToString());
            list_zmienne.Add("TaxThreshold1precent"); list_wartosci.Add(this.TaxThreshold1precent.ToString());
            list_zmienne.Add("TaxThreshold1value"); list_wartosci.Add(this.TaxThreshold1value.ToString());
            list_zmienne.Add("TaxThreshold2precent"); list_wartosci.Add(this.TaxThreshold2precent.ToString());
            list_zmienne.Add("TaxThreshold2value"); list_wartosci.Add(this.TaxThreshold2value.ToString());
            list_zmienne.Add("TaxThreshold3precent"); list_wartosci.Add(this.TaxThreshold3precent.ToString());
            list_zmienne.Add("LocalWorker"); list_wartosci.Add(this.LocalWorker.ToString());
            list_zmienne.Add("CommuterWorker"); list_wartosci.Add(this.CommuterWorker.ToString());
            list_zmienne.Add("TaxAdvance"); list_wartosci.Add(this.TaxAdvance.ToString());
            list_zmienne.Add("TaxDeductibleExpenses"); list_wartosci.Add(this.TaxDeductibleExpenses.ToString());
            list_zmienne.Add("PensionablePay"); list_wartosci.Add(this.PensionablePay.ToString());
            list_zmienne.Add("SocialPensionContribution"); list_wartosci.Add(this.SocialPensionContribution.ToString());
            list_zmienne.Add("SocialPensionContributionWorker"); list_wartosci.Add(this.SocialPensionContributionWorker.ToString());
            list_zmienne.Add("SickPay"); list_wartosci.Add(this.SickPay.ToString());
            list_zmienne.Add("Resultant"); list_wartosci.Add(this.Resultant.ToString());
            list_zmienne.Add("LabourFund"); list_wartosci.Add(this.LabourFund.ToString());
            list_zmienne.Add("Funds"); list_wartosci.Add(this.Funds.ToString());
            list_zmienne.Add("HealthInsurance"); list_wartosci.Add(this.HealthInsurance.ToString());
            list_zmienne.Add("PartUndeductFromTax"); list_wartosci.Add(this.PartUndeductFromTax.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"ValueOfTaxReduction FLOAT, " +
                $"TaxThreshold1precent FLOAT, " +
                $"TaxThreshold1value FLOAT, " +
                $"TaxThreshold2precent FLOAT, " +
                $"TaxThreshold2value FLOAT, " +
                $"TaxThreshold3precent FLOAT, " +
                $"LocalWorker FLOAT, " +
                $"CommuterWorker FLOAT, " +
                $"TaxAdvance FLOAT, " +
                $"TaxDeductibleExpenses FLOAT, " +
                $"PensionablePay FLOAT, " +
                $"SocialPensionContribution FLOAT, " +
                $"SocialPensionContributionWorker FLOAT, " +
                $"SickPay FLOAT, " +
                $"Resultant FLOAT, " +
                $"LabourFund FLOAT, " +
                $"Funds FLOAT, " +
                $"HealthInsurance FLOAT, " +
                $"PartUndeductFromTax FLOAT, " +
                $"PRIMARY KEY(Id AUTOINCREMENT))");
        }
        public int SqlInsert()
        {
            SqlQuery();
            return SqlLiteDataAcces.WprowadzWierszPobierzId(this.tabela, this.list_zmienne, this.list_wartosci);
        }
        public void SqlUpdate()
        {
            SqlQuery();
            SqlLiteDataAcces.UpdateWierszId(this.tabela, this.list_zmienne, this.list_wartosci, this.Id);
        }
    }
}
