using System.Collections.Generic;

namespace WPF_BussinesNotesLibrary.Models
{
    public class ProgramSetupBoolModel
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }
        public bool Wartosc { get; set; }


        public string tabela = "ProgramSetupBool";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("Nazwa"); list_wartosci.Add(this.Nazwa.ToString());
            list_zmienne.Add("Wartosc"); list_wartosci.Add(this.Wartosc.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"Nazwa TEXT, " +
                $"Wartosc BOOL, " +
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
