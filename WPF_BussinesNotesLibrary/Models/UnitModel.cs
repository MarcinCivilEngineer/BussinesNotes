using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BussinesNotesLibrary.Models
{
    public class UnitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ///
        public string tabela = "Unit";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("Name"); list_wartosci.Add(this.Name.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"Name TEXT, " +
                $"PRIMARY KEY(Id AUTOINCREMENT))");

            new UnitModel { Id = 1, Name = "r-g" }.SqlInsert();
            new UnitModel { Id = 2, Name = "m-g" }.SqlInsert();
            new UnitModel { Id = 3, Name = "m" }.SqlInsert();
            new UnitModel { Id = 4, Name = "szt." }.SqlInsert();
            new UnitModel { Id = 5, Name = "kg" }.SqlInsert();
            new UnitModel { Id = 6, Name = "t" }.SqlInsert();
            new UnitModel { Id = 7, Name = "pal" }.SqlInsert();
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
