using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using AutoMapper.Internal.Mappers;
using Movie.Authorization.Roles;
using Movie.Enities;
using Movie.TheMovies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.TheMovies
{
	public class MovieAppService :  ApplicationService, IMovieAppService
	{
		private readonly IRepository<TheMovie,long> _movieRepository;
		public MovieAppService(IRepository<TheMovie,long> movieRepository)
		{
			_movieRepository = movieRepository;
		}
		public  async Task Create(MovieInput input)
		{
			try
			{
			 var movie = 	ObjectMapper.Map<TheMovie>(input);
				_movieRepository.Insert(movie);
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message);
			}
		}

		public Task Delete(EntityDto<long> input)
		{
			try
			{
				_movieRepository.Delete(input.Id);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message);
			}
		}

		public async Task<MovieListDto> Get(long Id)
		{
			try
			{
				var movie = _movieRepository.Get(Id);
				return  ObjectMapper.Map<MovieListDto>(movie);
			}
			catch (Exception ex)
			{
				throw new UserFriendlyException(ex.Message);
			}
		}

		public async Task<ListResultDto<MovieListDto>> GetAll()
		{
			try
			{
				var query = await _movieRepository.GetAllListAsync();
				var ouput =  ObjectMapper.Map<List<MovieListDto>>(query);
				return new ListResultDto<MovieListDto>
				(ouput);
				
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message);
			}
		}

		public async Task Update(MovieDtoUpdate input)
		{
			try
			{
				var movie = _movieRepository.Get(input.Id);
				if(movie != null)
				{
					ObjectMapper.Map(input, movie);
					_movieRepository.Update(movie);
				}
			}
			catch (Exception ex)
			{
				throw new UserFriendlyException(ex.Message);
			}
		}
	}
}
