using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BussinesNotesLibrary.Models
{
    public class ProgramDefaultSetupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }


        public string tabela = "ProgramDefaultSetup";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("Name"); list_wartosci.Add(this.Name.ToString());
            list_zmienne.Add("Value"); list_wartosci.Add(this.Value.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"Name TEXT, " +
                $"Value TEXT, " +
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
