using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BussinesNotesLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public string PKWiU { get; set; }

        public int IdJednostka { get; set; }
        public double Vat { get; set; }
        public double Value { get; set; }

        public bool Visable { get; set; }

        public string tabela = "Product";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("Nazwa"); list_wartosci.Add(this.Nazwa.ToString());
            list_zmienne.Add("PKWiU"); list_wartosci.Add(this.PKWiU.ToString());
            list_zmienne.Add("IdJednostka"); list_wartosci.Add(this.IdJednostka.ToString());
            list_zmienne.Add("Vat"); list_wartosci.Add(this.Vat.ToString());
            list_zmienne.Add("Value"); list_wartosci.Add(this.Value.ToString());
            list_zmienne.Add("Visable"); list_wartosci.Add(this.Visable.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"Nazwa TEXT, " +
                $"PKWiU TEXT, " +
                $"IdJednostka INT, " +
                $"Vat FLOAT, " +
                $"Value FLOAT, " +
                $"Visable BOOL, " +
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
