﻿namespace PoCNeo4jNetCore.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Data.Queries;
    using Data.Queries.MovieQueries;
    using Domain.Model;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> moviesRepository;

        public MoviesController(IRepository<Movie> moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll([FromUri]int offset = 25)
        {
            var query = new GetAllMoviesQuery(offset);

            query.Validate();
            query.Build();

            var results = this.moviesRepository.Execute(query);

            return results;
        }

        [HttpGet]
        [Route("directors")]
        public IEnumerable<Movie> GetMoviesByDirector([FromUri]string director, [FromUri]int offset = 25)
        {
            var query = new GetMoviesByDirectorQuery(director, offset);

            query.Validate();
            query.Build();

            var results = this.moviesRepository.Execute(query);

            return results;
        }

        [HttpGet]
        [Route("actors")]
        public IEnumerable<Movie> GetMoviesByActor([FromUri]string actor, [FromUri]int offset = 25)
        {
            var query = new GetMoviesByActorQuery(actor, offset);

            query.Validate();
            query.Build();

            var results = this.moviesRepository.Execute(query);

            return results;
        }
    }
}