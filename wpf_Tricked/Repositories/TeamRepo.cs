using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Namespaces
using wpf_Tricked.Models;

namespace wpf_Tricked.Repositories
{
    public class TeamRepo : IGenericRepo<Teams>
    {
        #region Variables & Properties
        public string LoadStatement => "SELECT Name, Rank FROM TEAMS";

        public string UpdateStatement => "";

        public string RemoveStatement => "";

        public string AddStatement => "";
        #endregion

        #region Load
        public void Load(ObservableCollection<Teams> collection)
        {
            SqlRepo.Connect();
            SqlCommand cmd = new(LoadStatement, SqlRepo.sqlConn);

            //Clear List
            collection.Clear();

            //Read all rows, then adds them to the private Collection
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Teams loadTeam = new Teams(
                        (string)reader["Name"],
                        (int)reader["Rank"]
                        );

                    collection.Add(loadTeam);
                }
            }
            SqlRepo.Disconnect();
        }
        #endregion

        #region Update
        public void Update(Teams updated, int index, ObservableCollection<Teams> collection)
        {
            //
        }
        #endregion

        #region Remove
        public void Remove(Teams selected)
        {
            //
        }
        #endregion

        #region Add
        public void Add()
        {
            //
        }
        #endregion
    }
}
