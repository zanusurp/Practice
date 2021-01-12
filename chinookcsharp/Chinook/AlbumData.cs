using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook
{
    public class AlbumData
    {
        public Album SelectById(int albumId)
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("select * from Album where AlbumId = @AlbumId ", connection);

            SqlParameter parameter = new SqlParameter("@AlbumId", System.Data.SqlDbType.Int);
            parameter.Value = albumId;

            command.Parameters.Add(parameter);

            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            Album album = new Album();
            while (reader.Read())
            {

                album.AlbumId = reader.GetInt32(0);
                album.Title= reader.GetString(1);
                album.ArtistId= reader.GetInt32(2);

                
            }

            reader.Close();

            return album;
        }
        public List<Album> Select()
        {
            using (SqlConnection connection = CreatAndOpenConnection())
            {
                SqlCommand command = CreateCommand("select * from Album", connection);

                ReadAlbum(command);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                List<Album> list = new List<Album>();
                while (reader.Read())
                {
                    Album album = new Album();
                    album.AlbumId = reader.GetInt32(0);
                    album.Title = reader.GetString(1);
                    album.ArtistId = reader.GetInt32(2);

                    list.Add(album);
                }

                reader.Close();

                return list;
            }

            
           
        }
        public int getCount()
        {
            using (SqlConnection connection = CreatAndOpenConnection())
            {
                SqlCommand command = CreateCommand("select count(*) from Album", connection);
                return (int)command.ExecuteScalar();
                
            }
            //connection.Close();
        }
        private static void ReadAlbum(SqlCommand command)
        {
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int albumId = reader.GetInt32(0);
                string title = reader.GetString(1);
                int artistId = reader.GetInt32(2);

                Console.WriteLine($"album : {albumId} title : {title} artistId :  {artistId}");
            }
            reader.Close();
        }
        private static SqlCommand CreateCommand(string v, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = v;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            return command;
        }
        private static SqlConnection CreatAndOpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"server=127.0.0.1\MSSQLSERVER,1433;database=Chinook;uid=sa;pwd=tltmxpa";
            connection.Open();
            return connection;
        }
    }
}
