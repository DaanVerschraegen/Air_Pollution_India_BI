using System.Data;
using System.IO;

namespace Staging_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertCSVToDataTable(@"D:\School\AP\2019-2020\Semester 1\Intro BI\Data files\data.csv");
            
        }
        
        private static DataTable ConvertCSVToDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split(',');

                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(',');
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataRow[i] = rows[i];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        /*private static void WriteToDatabase(DataTable dataTable)
        {
            string connectionString =
                "Data Source=DESKTOP-AEDDPJR;" +
                "Initial Catalog=AirPolutionIndiaStagingArea;" +
                "Integrated Security=True;" +
                "System.Data.SqlClient;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insertDataTable", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@policyID", SqlDbType.Int).Value = 12;
                    cmd.Parameters.Add("@statecode", SqlDbType.VarChar).Value = "blagh2";
                    cmd.Parameters.Add("@county", SqlDbType.VarChar).Value = "blagh3";

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }*/
    }
}