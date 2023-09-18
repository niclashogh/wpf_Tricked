using System.Data.SqlClient;
using System.Data;

namespace wpf_Tricked.Repositories
{
    public class SqlRepo
    {
        //Variables
        private static string sqlLogin { get; } = @"Data Source=(localdb)\local_db; Integrated Security=true;";

        //Establish Connection
        public static SqlConnection sqlConn { get; } = new(sqlLogin);

        #region (Dis)Connect
        public static void Connect()
        {
            if (sqlConn.State == ConnectionState.Open)
            {
                Disconnect();
            }

            sqlConn.Open();
        }

        public static void Disconnect()
        {
            sqlConn.Close();
        }
        #endregion
    }
}
