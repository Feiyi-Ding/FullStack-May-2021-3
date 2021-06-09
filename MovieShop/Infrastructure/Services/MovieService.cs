using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighestRevenueMovie();

            var movieCardList = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCardList.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                    Title = movie.Title
                });
            }

            return movieCardList;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailsById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            // if not found
            var response = new MovieDetailsResponseModel();
            response.Id = movie.Id;
            response.Title = movie.Title;
            response.PosterUrl = movie.PosterUrl;
            response.BackdropUrl = movie.BackdropUrl;
            response.Rating = movie.Rating;
            response.Overview = movie.Overview;
            response.Tagline = movie.Tagline;
            response.Budget = movie.Budget;
            response.Revenue = movie.Revenue;
            response.ImdbUrl = movie.ImdbUrl;
            response.TmdbUrl = movie.TmdbUrl;
            response.RunTime = movie.RunTime;
            response.Price = movie.Price;
            response.ReleaseDate = movie.ReleaseDate;
            //var genres = new List<GenreResponseModel>();
            //List<Genre> gList = movie.Genres.ToList();
            //foreach (var genre in gList)
            //{
            //    genres.Add(new GenreResponseModel
            //    {
            //        Id = genre.Id,
            //        Name = genre.Name,
            //    });

            //}
            //response.Genres = genres;

            return response;
        }
    }
}
