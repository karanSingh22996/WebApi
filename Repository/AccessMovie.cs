using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class AccessMovie
    {
        public async Task<IList<MovieModel>> GetAllMovies()
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("getMovies", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                connection.Close();
                return moveDetails.AsList();
            }
        }
        public async Task<IList<MovieModel>> GetMovieById(int id)
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("getMovieById",id, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                
               return moveDetails.AsList();
            }
        }

        //public async Task<IList<MovieModel>> AddMovies(MovieModel movieModel)
        //{
        //    List<SqlCommand> list = new List<SqlCommand>();
        //    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
        //    {
        //        SqlCommand cmd = new SqlCommand("addMovie", connection);
        //        //SqlCommand cmd = new SqlCommand("getMovieById", connection);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", movieModel.Id);
        //        cmd.Parameters.AddWithValue("@movieName", movieModel.MovieName);
        //        cmd.Parameters.AddWithValue("@actor", movieModel.Actor);
        //        cmd.Parameters.AddWithValue("@director", movieModel.Director);
        //        cmd.Parameters.AddWithValue("@producer", movieModel.Producer);
        //        cmd.Parameters.AddWithValue("@dor", movieModel.DateOfRelease);
        //        list.Add(cmd);
        //        connection.Close();
        //        ////var moveDetails = await connection.QueryAsync<MovieModel>("addMovies", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        //        connection.Close();
        //        cmd.ExecuteNonQuery();
        //        ////return list;
        //    }
        //}
        public async Task<IList<PersonTypeModel>> GetActor()
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<PersonTypeModel>("getActor", commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                return moveDetails.AsList();
            }
        }
        public async Task<IList<PersonTypeModel>> GetDirector()
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<PersonTypeModel>("getDirector", commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                return moveDetails.AsList();
            }
        }
        public async Task<IList<PersonTypeModel>> GetProducer()
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<PersonTypeModel>("getProducer", commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                return moveDetails.AsList();
            }
        }
        public async Task<IList<MovieModel>> DeleteMovie(int id)
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("deleteMovie",id, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                return moveDetails.AsList();
            }
        }
        public async Task<IList<MovieModel>> EditMovie(int id,string name,string dname,string pname,string dt)
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("Edit",new {id, name, dname, pname, dt }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                return moveDetails.AsList();
            }
        }
        public async Task<IList<MovieModel>> AddMovie(MovieModel movie)
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("Edit", new { movie.MovieName, movie.Director, movie.Producer,movie.DateOfRelease }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                return moveDetails.AsList();
            }
        }


    }
}
