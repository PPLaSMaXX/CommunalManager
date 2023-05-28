using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ConsumptionHelper
{
    static public class SqlContoller
    {
        public static MySqlConnection sqlConnection = new MySqlConnection(@"Server=localhost;port=3306;Database=communalschema;User Id=root;password=133721");
        static public void Connect()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
            }
            catch
            {
                MessageBox.Show("Cannot connect to the DB", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
