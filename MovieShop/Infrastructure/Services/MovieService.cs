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
            var response = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                RunTime = movie.RunTime,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault()
            };

            response.Genres = new List<GenreResponseModel>();
            foreach (var genre in movie.MovieGenres)
            {
                response.Genres.Add(new GenreResponseModel { Id = genre.Genre.Id, Name = genre.Genre.Name });
            }

            response.Casts = new List<CastResponseModel>();
            foreach (var cast in movie.MovieCasts)
            {
                response.Casts.Add(new CastResponseModel { Id = cast.CastId, Name = cast.Cast.Name, ProfilePath = cast.Cast.ProfilePath, Character = cast.Character });
            }

            return response;
        }
    }
}
