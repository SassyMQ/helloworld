/************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************
 Created By: EJ Alexandra - 2016
             An Abstract Level, llc
 License:    Mozilla Public License 2.0
 ************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

using helloworld.Lib.DataClasses;

using CoreLibrary.Extensions;

namespace helloworld.Lib.SqlDataManagement
{
    public partial class SqlDataManager : IDisposable
    {
        public SqlDataManager() : this(SqlDataManager.LastConnectionString) 
        {
            this.Schema = "dbo";
        }
    
        public SqlDataManager(String connectionString)
        {
            this.Schema = "dbo";
            this.ConnectionString = connectionString;
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                this.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }
        }

        public SqlDataManager(String dataSourceName, String dbName) 
        {
            this.Schema = "dbo";
            this.DataSourceName = dataSourceName;
            this.DBName = dbName;
        }
        
        public void Dispose() 
        {
            this.IsDisposed = true;
        }
        
        public static string LastConnectionString { get; set; }
        public string ConnectionString { get; set; }
        public String DataSourceName { get; set; }
        public String DBName { get; set; }
        public Boolean IsDisposed { get; set; }
        public String Schema { get; set; }
        

  
      
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Galaxy galaxy)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Galaxy] (  [GalaxyId]  , [createdTime]  , [Name]  , [HaveVisited]  , [Notes])
                                    VALUES (@GalaxyId, @createdTime, @Name, @HaveVisited, @Notes)", this.Schema);

                
                if (ReferenceEquals(galaxy.GalaxyId, null)) cmd.Parameters.AddWithValue("@GalaxyId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@GalaxyId", galaxy.GalaxyId);
                
                if (ReferenceEquals(galaxy.createdTime, null) ||
                    (galaxy.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", galaxy.createdTime);
                
                if (ReferenceEquals(galaxy.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", galaxy.Name);
                
                if (ReferenceEquals(galaxy.HaveVisited, null)) cmd.Parameters.AddWithValue("@HaveVisited", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@HaveVisited", galaxy.HaveVisited);
                
                if (ReferenceEquals(galaxy.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", galaxy.Notes);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Galaxy galaxy)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = galaxy.GalaxyId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Galaxy] WHERE GalaxyId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(galaxy);
                else return this.Insert(galaxy);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllGalaxies<T>()
            where T : Galaxy, new()
        {
            return this.GetAllGalaxies<T>(String.Empty);
        }

        
        public List<T> GetAllGalaxies<T>(String whereClause) //changed
            where T : Galaxy, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Galaxy]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T galaxy = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("GalaxyId"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          galaxy.GalaxyId = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("createdTime"); // false
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          galaxy.createdTime = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          galaxy.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("HaveVisited"); // false
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          galaxy.HaveVisited = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Notes"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          galaxy.Notes = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(galaxy);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Galaxy
        /// </summary>
        /// <returns></returns>
        public int Update(Galaxy galaxy)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Galaxy] SET 
                                    [createdTime] = @createdTime, [Name] = @Name, [HaveVisited] = @HaveVisited, [Notes] = @Notes
                                    WHERE  [GalaxyId] = @GalaxyId", this.Schema);

                
                
                if (ReferenceEquals(galaxy.GalaxyId, null)) cmd.Parameters.AddWithValue("@GalaxyId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@GalaxyId", galaxy.GalaxyId);
                
                
                if (ReferenceEquals(galaxy.createdTime, null) ||
                    (galaxy.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", galaxy.createdTime);
                
                
                if (ReferenceEquals(galaxy.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", galaxy.Name);
                
                
                if (ReferenceEquals(galaxy.HaveVisited, null)) cmd.Parameters.AddWithValue("@HaveVisited", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@HaveVisited", galaxy.HaveVisited);
                
                
                if (ReferenceEquals(galaxy.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", galaxy.Notes);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Galaxy
        /// </summary>
        /// <returns></returns>
        public int Delete(Galaxy galaxy)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Galaxy] 
                                    WHERE  [GalaxyId] = @GalaxyId", this.Schema);
                                    
                
                if (ReferenceEquals(galaxy.GalaxyId, null)) cmd.Parameters.AddWithValue("@GalaxyId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@GalaxyId", galaxy.GalaxyId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
      
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Astronomer astronomer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Astronomer] (  [AstronomerId]  , [createdTime]  , [DOB]  , [Name])
                                    VALUES (@AstronomerId, @createdTime, @DOB, @Name)", this.Schema);

                
                if (ReferenceEquals(astronomer.AstronomerId, null)) cmd.Parameters.AddWithValue("@AstronomerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AstronomerId", astronomer.AstronomerId);
                
                if (ReferenceEquals(astronomer.createdTime, null) ||
                    (astronomer.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", astronomer.createdTime);
                
                if (ReferenceEquals(astronomer.DOB, null)) cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DOB", astronomer.DOB);
                
                if (ReferenceEquals(astronomer.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", astronomer.Name);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Astronomer astronomer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = astronomer.AstronomerId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Astronomer] WHERE AstronomerId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(astronomer);
                else return this.Insert(astronomer);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAstronomers<T>()
            where T : Astronomer, new()
        {
            return this.GetAllAstronomers<T>(String.Empty);
        }

        
        public List<T> GetAllAstronomers<T>(String whereClause) //changed
            where T : Astronomer, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Astronomer]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T astronomer = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AstronomerId"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          astronomer.AstronomerId = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("createdTime"); // false
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          astronomer.createdTime = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("DOB"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          astronomer.DOB = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          astronomer.Name = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(astronomer);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Astronomer
        /// </summary>
        /// <returns></returns>
        public int Update(Astronomer astronomer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Astronomer] SET 
                                    [createdTime] = @createdTime, [DOB] = @DOB, [Name] = @Name
                                    WHERE  [AstronomerId] = @AstronomerId", this.Schema);

                
                
                if (ReferenceEquals(astronomer.AstronomerId, null)) cmd.Parameters.AddWithValue("@AstronomerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AstronomerId", astronomer.AstronomerId);
                
                
                if (ReferenceEquals(astronomer.createdTime, null) ||
                    (astronomer.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", astronomer.createdTime);
                
                
                if (ReferenceEquals(astronomer.DOB, null)) cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DOB", astronomer.DOB);
                
                
                if (ReferenceEquals(astronomer.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", astronomer.Name);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Astronomer
        /// </summary>
        /// <returns></returns>
        public int Delete(Astronomer astronomer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Astronomer] 
                                    WHERE  [AstronomerId] = @AstronomerId", this.Schema);
                                    
                
                if (ReferenceEquals(astronomer.AstronomerId, null)) cmd.Parameters.AddWithValue("@AstronomerId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AstronomerId", astronomer.AstronomerId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
      
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Star star)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Star] (  [StarId]  , [createdTime]  , [FoundBy]  , [Galaxy]  , [Name]  , [Notes])
                                    VALUES (@StarId, @createdTime, @FoundBy, @Galaxy, @Name, @Notes)", this.Schema);

                
                if (ReferenceEquals(star.StarId, null)) cmd.Parameters.AddWithValue("@StarId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StarId", star.StarId);
                
                if (ReferenceEquals(star.createdTime, null) ||
                    (star.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", star.createdTime);
                
                if (ReferenceEquals(star.FoundBy, null)) cmd.Parameters.AddWithValue("@FoundBy", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@FoundBy", star.FoundBy);
                
                if (ReferenceEquals(star.Galaxy, null)) cmd.Parameters.AddWithValue("@Galaxy", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Galaxy", star.Galaxy);
                
                if (ReferenceEquals(star.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", star.Name);
                
                if (ReferenceEquals(star.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", star.Notes);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Star star)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = star.StarId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Star] WHERE StarId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(star);
                else return this.Insert(star);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllStars<T>()
            where T : Star, new()
        {
            return this.GetAllStars<T>(String.Empty);
        }

        
        public List<T> GetAllStars<T>(String whereClause) //changed
            where T : Star, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Star]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T star = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("StarId"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          star.StarId = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("createdTime"); // false
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          star.createdTime = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("FoundBy"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          star.FoundBy = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Galaxy"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          star.Galaxy = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          star.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Notes"); // false
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          star.Notes = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(star);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Star
        /// </summary>
        /// <returns></returns>
        public int Update(Star star)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Star] SET 
                                    [createdTime] = @createdTime, [FoundBy] = @FoundBy, [Galaxy] = @Galaxy, [Name] = @Name, [Notes] = @Notes
                                    WHERE  [StarId] = @StarId", this.Schema);

                
                
                if (ReferenceEquals(star.StarId, null)) cmd.Parameters.AddWithValue("@StarId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StarId", star.StarId);
                
                
                if (ReferenceEquals(star.createdTime, null) ||
                    (star.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", star.createdTime);
                
                
                if (ReferenceEquals(star.FoundBy, null)) cmd.Parameters.AddWithValue("@FoundBy", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@FoundBy", star.FoundBy);
                
                
                if (ReferenceEquals(star.Galaxy, null)) cmd.Parameters.AddWithValue("@Galaxy", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Galaxy", star.Galaxy);
                
                
                if (ReferenceEquals(star.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", star.Name);
                
                
                if (ReferenceEquals(star.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", star.Notes);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Star
        /// </summary>
        /// <returns></returns>
        public int Delete(Star star)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Star] 
                                    WHERE  [StarId] = @StarId", this.Schema);
                                    
                
                if (ReferenceEquals(star.StarId, null)) cmd.Parameters.AddWithValue("@StarId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@StarId", star.StarId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

                  
            
            

        public object LastIdentity { get; set; }
        public string ExecuteAsUser { get; set; }
        
        private SqlConnection CreateSqlConnection() 
        {
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = this.DataSourceName;
                scsb.InitialCatalog = this.DBName;
                scsb.IntegratedSecurity = true;
                this.ConnectionString = scsb.ConnectionString;
            }
            
            SqlDataManager.LastConnectionString = this.ConnectionString;
            
            return new SqlConnection(this.ConnectionString);
        }
        
        
        private void InitializeConnection(SqlConnection conn)
        {
            conn.Open();
            if (!String.IsNullOrEmpty(this.ExecuteAsUser))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("EXECUTE AS USER='{0}'", this.ExecuteAsUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

      