//-----------------------------------------------------------------------
// <copyright file="AccessMovie.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace WebApi.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using WebApi.Models;

    /// <summary>
    /// AccessMovie is a repository class
    /// </summary>
    public class AccessMovie
    {
        /// <summary>
        /// Gets all movies in database.
        /// </summary>
        /// <returns>list of movies</returns>
        /// <exception cref="System.Exception">system exception</exception>
        public async Task<IList<MovieModel>> GetAllMovies()
        {
            ////try is initilized to execute ignore the error and continue normal flow of the execution
            try
            {
                ////connection is established between databse and application
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
                {
                    var moveDetails = await connection.QueryAsync<MovieModel>("getMovies", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    connection.Close();
                    return moveDetails.AsList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the movie by identity.
        /// </summary>
        /// <param name="id">integer id.</param>
        /// <returns>list of movie</returns>
        public async Task<IList<MovieModel>> GetMovieById(int id)
        {
            ////try is initilized to execute ignore the error and continue normal flow of the execution
            try
            {
                ////connection is established between databse and application
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
                {
                    var moveDetails = await connection.QueryAsync<MovieModel>("getMovieById", id, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    connection.Close();
                    return moveDetails.AsList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// Gets the director.
        /// </summary>
        /// <returns>list of director</returns>
        /// <exception cref="System.Exception">system exception</exception>
        public async Task<IList<PersonTypeModel>> GetPerson(int id)
        {
            ////try is initilized to execute ignore the error and continue normal flow of the execution
            try
            {
                ////connection is established between databse and application
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
                {
                    var moveDetails = await connection.QueryAsync<PersonTypeModel>("getPerson",new { id }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    connection.Close();
                    return moveDetails.AsList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the movie.
        /// </summary>
        /// <param name="id">integer id</param>
        /// <exception cref="System.Exception">system exception</exception>
        public void DeleteMovie(int id)
        {
            ////try is initilized to execute ignore the error and continue normal flow of the execution
            try
            {
                ////connection is established between databse and application
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
                {
                    var moveDetails = connection.Execute("deleteMovie", new { id = id }, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Edits the movie.
        /// </summary>
        /// <param name="model">The movie model.</param>
        /// <returns>boolean true and false</returns>
        /// <exception cref="System.Exception">system exception</exception>
        public bool EditMovie(MovieModel model)
        {
            ////try is initilized to execute ignore the error and continue normal flow of the execution
            try
            {
                ////connection is established between databse and application
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
                {
                    int rowsAffected = connection.Execute("Edit", new { model.Id, model.MovieName, model.Actor, model.Director, model.Producer, model.DateOfRelease }, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Adds the movie.
        /// </summary>
        /// <param name="movie">The movie model.</param>
        /// <returns>boolean true and false</returns>
        /// <exception cref="System.Exception">system exception</exception>
        public bool AddMovie(MovieModel movie)
        {
            ////try is initilized to execute ignore the error and continue normal flow of the execution
            try
            {
                ////connection is established between databse and application
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Bollywood;Integrated Security=True"))
                {
                    int rowsAffected = connection.Execute("addMovies", new { movie.MovieName, movie.Director, movie.Producer, movie.DateOfRelease }, commandType: CommandType.StoredProcedure);
                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}