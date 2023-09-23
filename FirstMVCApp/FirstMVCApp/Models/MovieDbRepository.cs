using FirstMVCApp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;

namespace FirstMVCApp.Models
{
    public class MovieDbRepository
    {
        public static List<Movie> GetMovieList()
        {
            List<Movie> movielist = new List<Movie>();
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand selectmvcmd = cn.CreateCommand();
                String selectAllMvs = "Select * from mvtbl";
                selectmvcmd.CommandText = selectAllMvs;
                SqlDataReader mvdr = selectmvcmd.ExecuteReader();
                while (mvdr.Read())
                {
                    Movie movie = new Movie
                    {
                        Id = mvdr.GetInt32(0),
                        Title = mvdr.GetString(1),
                        Language = mvdr.GetString(2),
                        Hero = mvdr.GetString(3),
                        Director = mvdr.GetString(4),
                        MusicDirector = mvdr.GetString(5),
                        ReleaseDate = mvdr.GetDateTime(6),
                        MovieCost = mvdr.GetInt32(7),
                        Collection = mvdr.GetInt32(8),
                        Review = mvdr.GetInt32(9)

                    };
                    movielist.Add(movie);
                }
            }
            return movielist;
        }
		public static Movie GetMovieById(int id)
		{
			Movie movieFound = null;
			using (SqlConnection cn = SqlHelper.CreateConnection())
			{
				if (cn.State != ConnectionState.Open)
				{
					cn.Open();
				}
				SqlCommand selectmoviecmd = cn.CreateCommand();
				String selectMovies = "Select * from movietbl where mID=@id";
				selectmoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
				selectmoviecmd.CommandText = selectMovies;
				SqlDataReader mvdr = selectmoviecmd.ExecuteReader();
				while (mvdr.Read())
				{
					movieFound = new Movie
					{
						Id = mvdr.GetInt32(0),
						Title = mvdr.GetString(1),
						Language = mvdr.GetString(2),
						Hero = mvdr.GetString(3),
						Director = mvdr.GetString(4),
						MusicDirector = mvdr.GetString(5),
						ReleaseDate = mvdr.GetDateTime(6),
						MovieCost = mvdr.GetInt32(7),
						Collection = mvdr.GetInt32(8),
						Review = mvdr.GetInt32(9)
					};
				}
			}
			return movieFound;
		}
		public static int AddNewMovie(Movie newMovie)
		{
			int query_result = 0;
			using (SqlConnection cn = SqlHelper.CreateConnection())
			{
				if (cn.State != ConnectionState.Open)
				{
					cn.Open();
				}
				SqlCommand insertMvcmd = cn.CreateCommand();
				String insertNewMvQuery = "insert into mvtbl values( @id,@title,@language,@hero,@director,@musicdirector,@releasedate,@moviecost,@collection,@review )";
				insertMvcmd.Parameters.Add("@id", SqlDbType.Int).Value = newMovie.Id;
				insertMvcmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = newMovie.Title;
				insertMvcmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = newMovie.Language;
				insertMvcmd.Parameters.Add("@hero", SqlDbType.NVarChar).Value = newMovie.Hero;
				insertMvcmd.Parameters.Add("@director", SqlDbType.NVarChar).Value = newMovie.Director;
				insertMvcmd.Parameters.Add("@musicdirector", SqlDbType.NVarChar).Value = newMovie.MusicDirector;
				insertMvcmd.Parameters.Add("@releasedate", SqlDbType.DateTime).Value = newMovie.ReleaseDate;
				insertMvcmd.Parameters.Add("@moviecost", SqlDbType.Int).Value = newMovie.MovieCost;
				insertMvcmd.Parameters.Add("@collection", SqlDbType.Int).Value = newMovie.Collection;
				insertMvcmd.Parameters.Add("@review", SqlDbType.Int).Value = newMovie.Review;
				insertMvcmd.CommandText = insertNewMvQuery;
				query_result = insertMvcmd.ExecuteNonQuery();
			}
			return query_result;

		}
		public static int UpdateMovie(Movie modifiedMovie)
		{
			int query_result = 0;
			using (SqlConnection cn = SqlHelper.CreateConnection())
			{
				if (cn.State != ConnectionState.Open)
				{
					cn.Open();
				}
				SqlCommand updateMvcmd = cn.CreateCommand();
				String updateMvQuery = "insert into mvtbl values( @id,@title,@language,@hero,@director,@musicdirector,@releasedate,@moviecost,@collection,@review )";
				updateMvcmd.Parameters.Add("@id", SqlDbType.Int).Value = modifiedMovie.Id;
				updateMvcmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = modifiedMovie.Title;
				updateMvcmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = modifiedMovie.Language;
				updateMvcmd.Parameters.Add("@hero", SqlDbType.NVarChar).Value = modifiedMovie.Hero;
				updateMvcmd.Parameters.Add("@director", SqlDbType.NVarChar).Value = modifiedMovie.Director;
				updateMvcmd.Parameters.Add("@musicdirector", SqlDbType.NVarChar).Value = modifiedMovie.MusicDirector;
				updateMvcmd.Parameters.Add("@releasedate", SqlDbType.DateTime).Value = modifiedMovie.ReleaseDate;
				updateMvcmd.Parameters.Add("@moviecost", SqlDbType.Int).Value = modifiedMovie.MovieCost;
				updateMvcmd.Parameters.Add("@collection", SqlDbType.Int).Value = modifiedMovie.Collection;
				updateMvcmd.Parameters.Add("@review", SqlDbType.Int).Value = modifiedMovie.Review;
				updateMvcmd.CommandText = updateMvQuery;
				query_result = updateMvcmd.ExecuteNonQuery();
			}
			return query_result;
		}
		
		public static int DeleteMovie(int id)
		{
			int query_result = 0;
			using (SqlConnection cn = SqlHelper.CreateConnection())
			{
				if (cn.State != ConnectionState.Open)
				{
					cn.Open();
				}
				SqlCommand deleteMoviecmd = cn.CreateCommand();
				String deleteMovieQuery = "Delete from mvtbl where Id=@id";
				deleteMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
				deleteMoviecmd.CommandText = deleteMovieQuery;
				query_result = deleteMoviecmd.ExecuteNonQuery();
			}
			return query_result;
		}

	
	}
}
