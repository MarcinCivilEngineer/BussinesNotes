using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BussinesNotesLibrary.Models
{
    public class VatModel
    {
        /// <summary>
        /// Contain Value of Tax VAT
        /// </summary>
        public int Id { get; set; }
        public double Value { get; set; }

        ///
        public string tabela = "Vat";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("Value"); list_wartosci.Add(this.Value.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"Value FLOAT, " +
                $"PRIMARY KEY(Id AUTOINCREMENT))");

            new VatModel { Id = 1, Value = 0 }.SqlInsert();
            new VatModel { Id = 2, Value = 8 }.SqlInsert();
            new VatModel { Id = 3, Value = 22 }.SqlInsert();
            new VatModel { Id = 4, Value = 23 }.SqlInsert();

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
