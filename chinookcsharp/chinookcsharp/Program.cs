using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinookcsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Select();

        }

        private static void Select()
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("select * from Album", connection);

            ReadAlbum(command);
            connection.Close();
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


        private static void Insert()
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("insert into album values (@Title, @ArtistId)", connection);


            SqlParameter parameter = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar);
            parameter.Value = $"new album at {DateTime.Now:T}";
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@ArtistId", System.Data.SqlDbType.Int);
            parameter.Value = 1;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            connection.Close();
            //reader.Close();
           // connection.Close();
        }
        private static void Update()
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("update Album set Title = @Title, ArtistId = @ArtistId whee AlbumId = @AlbumId", connection);


            SqlParameter parameter = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar);
            parameter.Value = $"new album at {DateTime.Now:T}";
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@ArtistId", System.Data.SqlDbType.Int);
            parameter.Value = 1;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@ArtistId", System.Data.SqlDbType.Int);
            parameter.Value = 348;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            connection.Close();
            //reader.Close();
            // connection.Close();
        }
        private static void Delete()
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("delete Album where AlbumId = @AlbumId ", connection);

            SqlParameter parameter = new SqlParameter("@ArtistId", System.Data.SqlDbType.Int);
            parameter.Value = 348;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            connection.Close();
            //reader.Close();
            // connection.Close();
        }
        private static void SelectById()
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("select Album where AlbumId = @AlbumId ", connection);

            SqlParameter parameter = new SqlParameter("@ArtistId", System.Data.SqlDbType.Int);
            parameter.Value = 348;
            command.Parameters.Add(parameter);

            ReadAlbum(command);
            connection.Close();
        }
        private static void Count()
        {
            SqlConnection connection = CreatAndOpenConnection();

            SqlCommand command = CreateCommand("select count(*) from Album", connection);
            int count = (int)command.ExecuteScalar();
            Console.WriteLine(count);
            
            
            connection.Close();
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
