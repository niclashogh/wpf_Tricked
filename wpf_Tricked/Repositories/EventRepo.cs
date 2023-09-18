using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
//Namespaces
using wpf_Tricked.Models;

namespace wpf_Tricked.Repositories
{
    public class EventRepo : IGenericRepo<Events>
    {
        #region Variables & Properties
        public string LoadStatement => "SELECT Location, Date, EventID FROM Events";

        public string UpdateStatement => "UPDATE Events SET Location = @Location, Date = @Date WHERE EventID = @At";

        public string RemoveStatement => "DELETE FROM Events WHERE EventID = @At";

        public string AddStatement => "INSERT INTO Events (Location, Date) VALUES (@Location, @Date)";
        #endregion

        #region Load
        public void Load(ObservableCollection<Events> collection)
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
                    Events loadEvent = new Events(
                        (string)reader["Location"],
                        (DateTime)reader["Date"],
                        (int)reader["EventID"]
                        );

                    collection.Add(loadEvent);
                }
            }
            SqlRepo.Disconnect();
        }
        #endregion

        #region Update
        public void Update(Events updated, int index, ObservableCollection<Events> collection)
        {
            //Variables & Properties
            int At = collection[index].EventID;

            //SQL
            SqlRepo.Connect();

            SqlCommand cmd = new(UpdateStatement, SqlRepo.sqlConn);
            cmd.Parameters.AddWithValue("@Location", updated.Location);
            cmd.Parameters.AddWithValue("@Date", updated.Date);
            cmd.Parameters.AddWithValue("@At", At);
            cmd.ExecuteNonQuery();

            SqlRepo.Disconnect();
        }
        #endregion

        #region Remove
        public void Remove(Events selected)
        {
            SqlRepo.Connect();

            SqlCommand cmd = new(RemoveStatement, SqlRepo.sqlConn);
            cmd.Parameters.AddWithValue("@At", selected.EventID);
            cmd.ExecuteNonQuery();

            SqlRepo.Disconnect();
        }
        #endregion

        #region Add
        public void Add()
        {
            SqlRepo.Connect();

            SqlCommand cmd = new(AddStatement, SqlRepo.sqlConn);
            cmd.Parameters.AddWithValue("@Location", "Location");
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            cmd.ExecuteNonQuery();

            SqlRepo.Disconnect();
        }
        #endregion
    }
}
