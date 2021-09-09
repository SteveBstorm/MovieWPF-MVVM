using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MovieService
    {
        private string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2014;Initial Catalog=NetAngularMovieDB;User ID=sa;Password=steve1983;Connect Timeout=60;";

        public IEnumerable<Movie> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Movie";
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Movie
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Synopsis = reader["Synopsis"].ToString(),
                                Realisator = reader["Realisator"].ToString(),
                                ReleaseYear = (int)reader["ReleaseYear"]
                            };
                        }
                    }
                    connection.Close();

                }
            }
        }

        public void Insert(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Movie (Title, Synopsis, ReleaseYear, Realisator)" +
                        " VALUES (@title, @synopsis, @ry, @real)";

                    cmd.Parameters.AddWithValue("title", m.Title);
                    cmd.Parameters.AddWithValue("synopsis", m.Synopsis);
                    cmd.Parameters.AddWithValue("ry", m.ReleaseYear);
                    cmd.Parameters.AddWithValue("real", m.Realisator);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }

        public void Delete(int Id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Movie WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}
