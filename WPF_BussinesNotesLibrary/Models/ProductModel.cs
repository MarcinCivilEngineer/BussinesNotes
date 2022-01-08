using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BussinesNotesLibrary.Models
{
    public class ProductModel
    {
        SqlLiteDataAcces da = new SqlLiteDataAcces();
        public int Id { get; set; }
        public string Name { get; set; }
        public string PKWiU { get; set; }
        public int IdUnit { get; set; }
        public UnitModel Unit
        {
            get
            {
                
                if (IdUnit > 0)
                {
                    return da.LoadUnit(id: this.IdUnit).First();

                }
                else
                {
                    return null;
                }
            }
        }
        public int IdProductType { get; set; }
        public ProductTypeModel ProductType
        {
            get
            {
                if (IdProductType > 0)
                {
                    return da.LoadProductType(id: this.IdProductType).First();

                }
                else
                {
                    return null;
                }
            }
        }
        public int IdVat { get; set; }
        public VatModel Vat
        {
            get
            {
                if (IdProductType > 0)
                {
                    return da.LoadVat(id: this.IdVat).First();

                }
                else
                {
                    return null;
                }
            }
        }
        public double Value { get; set; }
        public bool Visable { get; set; }

        public string tabela = "Product";
        private List<string> list_zmienne = new List<string>();
        private List<string> list_wartosci = new List<string>();
        public void SqlQuery()
        {
            list_zmienne.Clear();
            list_wartosci.Clear();
            list_zmienne.Add("Name"); list_wartosci.Add(this.Name.ToString());
            list_zmienne.Add("PKWiU"); list_wartosci.Add(this.PKWiU.ToString());
            list_zmienne.Add("IdUnit"); list_wartosci.Add(this.IdUnit.ToString());
            list_zmienne.Add("IdProductType"); list_wartosci.Add(this.IdProductType.ToString());
            list_zmienne.Add("IdVat"); list_wartosci.Add(this.IdVat.ToString());
            list_zmienne.Add("Value"); list_wartosci.Add(this.Value.ToString());
            list_zmienne.Add("Visable"); list_wartosci.Add(this.Visable.ToString());
        }
        public void SqlCreate()
        {
            SqlLiteDataAcces.UtworzTabele($"CREATE TABLE {tabela} (Id INTEGER NOT NULL UNIQUE, " +
                $"Name TEXT, " +
                $"PKWiU TEXT, " +
                $"IdUnit INT, " +
                $"IdProductType INT, " +
                $"IdVat INT, " +
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
