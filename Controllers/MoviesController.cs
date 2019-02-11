//-----------------------------------------------------------------------
// <copyright file="MoviesController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Models;
    using WebApi.Repository;

    /// <summary>
    /// Movies controller is a class which have control to execute
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        /// <summary>
        /// object of repository class access movie
        /// </summary>
        AccessMovie accessMovie = new AccessMovie();

        /// <summary>
        /// get movie method will return all the details of movie
        /// </summary>
        /// <returns>list of movie details</returns>
        [HttpGet]
        [Route("allmovies")]
        public IList<MovieModel> GetMovies()
        {
            try
            {
                IList<MovieModel> movies = accessMovie.GetAllMovies().Result;
                return movies;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// get movie by id
        /// </summary>
        /// <param name="id">id of integer</param>
        /// <returns>details of particular movie</returns>
        [HttpGet("{id}")]
        public IList<MovieModel> GetMovies(int id)
        {
            try
            {
                IList<MovieModel> movies = accessMovie.GetMovieById(id).Result;
                return movies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
        /// <summary>
        /// get the details of director
        /// </summary>
        /// <returns>listing details of director</returns>
        [Route("persontype")]
        [HttpGet("{id}")]
        public IList<PersonTypeModel> GetPersonType(int id)
        {
            try
            {
                IList<PersonTypeModel> movies = accessMovie.GetPerson(id).Result;
                return movies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// delete the data from database by id
        /// </summary>
        /// <param name="id">integer id</param>
        /// <returns>boolean true and false</returns>
        [Route("delete")]
        public bool Delete(int id)
        {
            try
            {
                accessMovie.DeleteMovie(id);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// update the movie details
        /// </summary>
        /// <param name="movieModel">movie model</param>
        /// <returns>action result</returns>
        [Route("update")]
        public ActionResult Update(MovieModel movieModel)
        {
            try
            {
                bool response = accessMovie.EditMovie(movieModel);
                return Ok(response);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// post method will add new record into the database
        /// </summary>
        /// <param name="movie">movie model</param>
        /// <returns>boolean true and false</returns>
        [Route("add")]
        public bool Post(MovieModel movie)
        {
            try
            {
                accessMovie.AddMovie(movie);
                return true;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}