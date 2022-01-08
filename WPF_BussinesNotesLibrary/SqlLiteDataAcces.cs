using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using WPF_BussinesNotesLibrary.Models;

namespace WPF_BussinesNotesLibrary
{

    public class SqlLiteDataAcces
    {
        private static string PlikBazyDanych = "BussinesNotesDB.db";

        public List<TaxModel> LoadTax(int id = 0)
        {
            string tabela = new TaxModel().tabela;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<TaxModel> output = new List<TaxModel>();
                cnn.Open();
                if (id != 0)
                {
                    output = cnn.Query<TaxModel>($"select * from {tabela} where id=" + id.ToString(), new DynamicParameters()).ToList();
                }
                else
                {
                    output = cnn.Query<TaxModel>($"select * from {tabela}", new DynamicParameters()).ToList();
                }
                cnn.Close();
                return output;
            }
        }

        public List<ProductModel> LoadProduct(int id = 0)
        {
            string tabela = new ProductModel().tabela;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<ProductModel> output = new List<ProductModel>();
                cnn.Open();
                if (id != 0)
                {
                    output = cnn.Query<ProductModel>($"select * from {tabela} where id=" + id.ToString(), new DynamicParameters()).ToList();
                }
                else
                {
                    output = cnn.Query<ProductModel>($"select * from {tabela}", new DynamicParameters()).ToList();
                }
                cnn.Close();
                return output;
            }
        }

        public List<UnitModel> LoadUnit(int id = 0, string nazwa="")
        {
            string tabela = new UnitModel().tabela;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UnitModel> output = new List<UnitModel>();
                cnn.Open();
                if (id != 0)
                {
                    output = cnn.Query<UnitModel>($"select * from {tabela} where id=" + id.ToString(), new DynamicParameters()).ToList();
                }
                else if (nazwa != "")
                {
                    output = cnn.Query<UnitModel>($"select * from {tabela} where Name='" + nazwa+"' ORDER BY Name ASC", new DynamicParameters()).ToList();
                }
                else
                {
                    output = cnn.Query<UnitModel>($"select * from {tabela} ORDER BY Name ASC", new DynamicParameters()).ToList();
                }
                cnn.Close();
                return output;
            }
        }

        public List<ProductTypeModel> LoadProductType(int id = 0, string nazwa = "")
        {
            string tabela = new ProductTypeModel().tabela;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<ProductTypeModel> output = new List<ProductTypeModel>();
                cnn.Open();
                if (id != 0)
                {
                    output = cnn.Query<ProductTypeModel>($"select * from {tabela} where id=" + id.ToString(), new DynamicParameters()).ToList();
                }
                else if (nazwa != "")
                {
                    output = cnn.Query<ProductTypeModel>($"select * from {tabela} where Name='" + nazwa + "' ORDER BY Name ASC", new DynamicParameters()).ToList();
                }
                else
                {
                    output = cnn.Query<ProductTypeModel>($"select * from {tabela} ORDER BY Name ASC", new DynamicParameters()).ToList();
                }
                cnn.Close();
                return output;
            }
        }
        public List<VatModel> LoadVat(int id = 0, double wartosc = 0)
        {
            string tabela = new VatModel().tabela;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<VatModel> output = new List<VatModel>();
                cnn.Open();
                if (id != 0)
                {
                    output = cnn.Query<VatModel>($"select * from {tabela} where id=" + id.ToString(), new DynamicParameters()).ToList();
                }
                else if (wartosc != 0)
                {
                    output = cnn.Query<VatModel>($"select * from {tabela} where Value='" + wartosc.ToString() + "' ORDER BY Value ASC", new DynamicParameters()).ToList();
                }
                else
                {
                    output = cnn.Query<VatModel>($"select * from {tabela} ORDER BY Value ASC", new DynamicParameters()).ToList();
                }
                cnn.Close();
                return output;
            }
        }
        public List<ProgramSetupBoolModel> LoadProgramSetupBool(string parametr = "")
        {

            string tabela = new ProgramSetupBoolModel().tabela;
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<ProgramSetupBoolModel> output = new List<ProgramSetupBoolModel>();
                cnn.Open();
                if (parametr != "")
                {
                    output = cnn.Query<ProgramSetupBoolModel>($"select * from {tabela} where nazwa='{parametr}'", new DynamicParameters()).ToList();
                }


                return output;

            }
        }



        public static void UsunTax(int id)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute($"delete from {new TaxModel().tabela} where id = " + id);
                cnn.Close();
            }
        }

        public static void WprowadzWiersz(string table, List<string> zmienne, List<string> wartosci)
        {

            string qZmienne = string.Join(",", zmienne);
            string qWartosci = string.Join("','", wartosci);

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute("insert into " + table + " (" + qZmienne + ") values ('" + qWartosci + "')");
                cnn.Close();
            }
        }
        public static int WprowadzWierszPobierzId(string table, List<string> zmienne, List<string> wartosci)
        {

            string qZmienne = string.Join(",", zmienne);
            string qWartosci = string.Join("','", wartosci);

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute("insert into " + table + " (" + qZmienne + ") values ('" + qWartosci + "')");
                int id = int.Parse(cnn.LastInsertRowId.ToString());
                cnn.Close();
                return id;
            }
        }
        public static void UpdateWierszId(string table, List<string> zmienne, List<string> wartosci, int id)
        {

            //string qZmienne = string.Join(",", zmienne);

            List<string> linia = new List<string>();

            for (int a = 0; a < zmienne.Count; a++)
            {
                linia.Add($" {zmienne[a]} = '{wartosci[a]}'");
            }

            string qWyrazenie = string.Join(",", linia);

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute($"update {table} SET {qWyrazenie} WHERE id = {id}");
                cnn.Close();
            }
        }
        public static void UsunTabele(List<string> tabele)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteCommand com = new SQLiteCommand(con))
                {
                    con.Open();                             // Open the connection to the database
                    foreach (string tabela in tabele)
                    {
                        com.CommandText = $"DROP TABLE IF EXISTS {tabela};";     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query
                    }
                    con.Close();                            // Close the connection to the database
                }
            }
        }
        public static void UtworzTabele(string wiersz)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteCommand com = new SQLiteCommand(con))
                {
                    con.Open();                             // Open the connection to the database
                    com.CommandText = wiersz;               // Set CommandText to our query that will create the table
                    com.ExecuteNonQuery();                  // Execute the query
                    con.Close();                            // Close the connection to the database
                }
            }

        }

        private static void UtworzPustaBazeDanych(string plik)
        {
            SQLiteConnection.CreateFile(plik);

            new ProgramSetupBoolModel().SqlCreate();

            new TaxModel().SqlCreate();

            new UnitModel().SqlCreate();
            new ProductTypeModel().SqlCreate();
            new ProductModel().SqlCreate();

            new VatModel().SqlCreate();

            
        }

        private static string LoadConnectionString()
        {
            if (!File.Exists(PlikBazyDanych))
            {
                UtworzPustaBazeDanych(PlikBazyDanych);
            }
            return "Data Source=.\\" + PlikBazyDanych;
        }
        public SqlLiteDataAcces()
        {

        }
    }
}
