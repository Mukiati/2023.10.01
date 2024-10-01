using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _2023._10._01
{
   public  class databasehandler
    {

        MySqlConnection connection;
            public databasehandler()
            {
                string username = "root";
                string password = "";
                string host = "localhost";
                string dbname = "pekseg";
                string connectionstring = $"username={username};password={password};host={host};database={dbname}";

                connection = new MySqlConnection(connectionstring);

            }
        public void Readall()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM `aruk`";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    pekaruk onearu = new pekaruk();
                    onearu.id = read.GetInt32(read.GetOrdinal("id"));
                    onearu.name = read.GetString(read.GetOrdinal("nev"));
                    onearu.amount = read.GetInt32(read.GetOrdinal("menyiseg"));
                    onearu.price = read.GetInt32(read.GetOrdinal("ar"));
                    pekaruk.pekaruks.Add(onearu);
                 
                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("sikerült");
            }
            catch (Exception e)
            {

                MessageBox.Show("Hiba" + e.Message);
            }
        }
        public void write(pekaruk onearu)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO `aruk`( `nev`, `menyiseg`, `ar`) VALUES ('{onearu.name}','{onearu.amount}','{onearu.price}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
              
                command.Dispose();
                connection.Close();
                MessageBox.Show("sikerült a hozzáírás");
                pekaruk.pekaruks.Add(onearu);

            }
            catch (Exception e)
            {

                MessageBox.Show("Hiba" + e.Message);
            }
        }
        public void delete(pekaruk onearu)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM `aruk` WHERE id = {onearu.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
             
                command.Dispose();
                connection.Close();
                MessageBox.Show("sikerülta törlés");
                pekaruk.pekaruks.Remove(onearu);
              
            }
            catch (Exception e)
            {
                MessageBox.Show("Hiba" + e.Message);
                
            }
        }
       
    }
}
