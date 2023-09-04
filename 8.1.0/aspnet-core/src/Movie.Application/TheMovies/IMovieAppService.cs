using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Builder;
using Movie.TheMovies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.TheMovies
{
	public interface IMovieAppService : IApplicationService
	{
		public Task<ListResultDto<MovieListDto>> GetAll();
		public Task Create(MovieInput input);
		public Task<MovieListDto> Get(long Id);
		public Task Update(MovieDtoUpdate input);
		public Task Delete(EntityDto<long> input);
	}
}
