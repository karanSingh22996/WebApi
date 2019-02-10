using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        AccessMovie accessMovie = new AccessMovie();
        [HttpGet]
        public IList<MovieModel> GetMovies()
        {

            IList<MovieModel> movies = accessMovie.GetAllMovies().Result;
            return movies;
        }
        [HttpGet("{id}")]
        public IList<MovieModel> GetMovies(int id)
        {
            IList<MovieModel> movies = accessMovie.GetMovieById(id).Result;
            return movies;
        }
        //public IList<MovieModel> AddMovies([Bind] MovieModel movieModel)
        //{
        //     accessMovie.AddMovies(movieModel);
        //    return movies;
        //}
        [Route("actor")]
        public IList<PersonTypeModel> GetActor()
        {
            IList<PersonTypeModel> movies = accessMovie.GetActor().Result;
            return movies;
        }
        [Route("director")]
        public IList<PersonTypeModel> GetDirector()
        {
            IList<PersonTypeModel> movies = accessMovie.GetDirector().Result;
            return movies;
        }
        [Route("director")]
        public IList<PersonTypeModel> GetProducer()
        {
            IList<PersonTypeModel> movies = accessMovie.GetProducer().Result;
            return movies;
        }
        [Route("delete")]
        public IList<MovieModel> Delete(int id)
        {
            IList<MovieModel> movies = accessMovie.DeleteMovie(id).Result;
            return movies;
        }
        [Route("update")]
        public IList<MovieModel> Put(int id,string name,string aname,string pname,string dname,string dt)
        {
            IList<MovieModel> movies = accessMovie.EditMovie(id,name,aname,dname,pname,dt).Result;
            return movies;
        }
        [Route("add")]
        public IList<MovieModel> Post(MovieModel movie)
        {
            IList<MovieModel> movies = accessMovie.AddMovie( movie).Result;
            return movies;
        }

    }
}