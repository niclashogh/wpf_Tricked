using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
//Namesspaces
using wpf_Tricked.Models;

namespace wpf_Tricked.Repositories
{
    public class ProfileRepo : IGenericRepo<Profiles>
    {
        #region Variables & Properties
        public string LoadStatement => "SELECT Name, IGN, Role, Elo FROM PROFILES";
        public string UpdateStatement => "UPDATE PROFILES SET Name = @Name, IGN = @IGN, Role = @Role, Elo = @Elo WHERE IGN = @At";
        public string RemoveStatement => "DELETE FROM PROFILES WHERE IGN = @At";
        public string AddStatement => "INSERT INTO PROFILES (Name, IGN, Role, Elo) VALUES (@Name, @IGN, @Role, @Elo)";
        #endregion

        #region Constructor
        public ProfileRepo()
        {

        }
        #endregion

        #region LOAD FROM SQL DATABASE
        public void Load(ObservableCollection<Profiles> collection)
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
                    Profiles loadProfile = new Profiles(
                        (string)reader["Name"],
                        (string)reader["IGN"],
                        (Roles)Enum.Parse(typeof(Roles), reader["Role"].ToString()),
                        (int)reader["Elo"]
                        );

                    collection.Add(loadProfile);
                }
            }
            SqlRepo.Disconnect();
        }
        #endregion

        #region Update
        public void Update(Profiles updated, int index, ObservableCollection<Profiles> collection)
        {
            //Variables & Properties
            string At = collection[index].IGN;

            //SQL
            SqlRepo.Connect();

            SqlCommand cmd = new(UpdateStatement, SqlRepo.sqlConn);
            cmd.Parameters.AddWithValue("@Name", updated.Name);
            cmd.Parameters.AddWithValue("@IGN", updated.IGN);
            cmd.Parameters.AddWithValue("@Role", updated.Role.ToString());
            cmd.Parameters.AddWithValue("@Elo", updated.Elo);
            cmd.Parameters.AddWithValue("@At", At);
            cmd.ExecuteNonQuery();

            SqlRepo.Disconnect();
        }
        #endregion

        #region Remove
        public void Remove(Profiles selected)
        {
            SqlRepo.Connect();
            
            SqlCommand cmd = new(RemoveStatement, SqlRepo.sqlConn);
            cmd.Parameters.AddWithValue("@At", selected.IGN); 
            cmd.ExecuteNonQuery();

            SqlRepo.Disconnect();
        }
        #endregion

        #region Add
        public void Add()
        {
            SqlRepo.Connect();

            SqlCommand cmd = new(AddStatement, SqlRepo.sqlConn);
            cmd.Parameters.AddWithValue("@Name", "Name");
            cmd.Parameters.AddWithValue("@IGN", "InGame Name");
            cmd.Parameters.AddWithValue("@Role", "AWP");
            cmd.Parameters.AddWithValue("@Elo", "0");
            cmd.ExecuteNonQuery();

            SqlRepo.Disconnect();
        }
        #endregion
    }
}