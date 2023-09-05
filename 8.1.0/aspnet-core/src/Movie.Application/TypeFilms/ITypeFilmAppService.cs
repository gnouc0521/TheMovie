using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Movie.Enities;
using Movie.TypeFilms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.TypeFilms
{
	public interface ITypeFilmAppService : IApplicationService
	{
		public Task CreateAsync(TypeFilmCreateDto input);
		public Task<ListResultDto<TypeFilmDto>> GetAll();
		public Task<TypeFilm> GetbyId(EntityDto entity);
		public Task Update(TypeFilmUpdate input);
		public Task Delete(EntityDto input);	 

	}
}
