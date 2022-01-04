using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BussinesNotesLibrary.Models
{
    public class ProductTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string tabela = "ProductType";
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

            new ProductTypeModel { Id = 1, Name = "Robocizna" }.SqlInsert();
            new ProductTypeModel { Id = 2, Name = "Materiał" }.SqlInsert();
            new ProductTypeModel { Id = 3, Name = "Sprzęt" }.SqlInsert();
            new ProductTypeModel { Id = 4, Name = "Inne" }.SqlInsert();
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
