using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Movie.Enities;
using Movie.TypeFilms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Movie.TypeFilms
{
	public class TypeFilmAppService : ApplicationService, ITypeFilmAppService
	{
		private readonly IRepository<TypeFilm> _typeFilmRepository;
		
		public TypeFilmAppService(IRepository<TypeFilm> typeFilmRepository)
		{
			_typeFilmRepository = typeFilmRepository;
		}

		public async Task CreateAsync(TypeFilmCreateDto input)
		{
			try
			{
				var typefilm = ObjectMapper.Map<TypeFilm>(input);
				_typeFilmRepository.Insert(typefilm);
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message);
			}
		}

		public async Task Delete(EntityDto input)
		{
			try
			{
				var typefilm = _typeFilmRepository.Get(input.Id);
				if(typefilm != null) {
					_typeFilmRepository.DeleteAsync(typefilm);
				} else { throw new Exception("NotFindTypeFilmWithId" + input.Id.ToString()); }
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message);
			}
		}

		public async Task<ListResultDto<TypeFilmDto>> GetAll()
		{
			try
			{
				var query = _typeFilmRepository.GetAll();
				 var output = ObjectMapper.Map<List<TypeFilmDto>>(query);
				return new ListResultDto<TypeFilmDto>
				{
					Items = output,
				};
			}
			catch (Exception ex)
			{
				throw new UserFriendlyException(ex.Message);
				throw;
			}
		}

		public async Task<TypeFilm> GetbyId(EntityDto entity)
		{
			try
			{
				var typefilm = _typeFilmRepository.Get(entity.Id);
				if(typefilm != null)
				{
					return typefilm;
				}
				else { throw new Exception("NotfindTypefilmWithId" + entity.Id.ToString()); }
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message);
			}
		}

		public async Task Update(TypeFilmUpdate input)
		{
			try
			{
				var typefilm =  _typeFilmRepository.Get(input.Id);
				if (input != null)
				{
					ObjectMapper.Map(input, typefilm);
					_typeFilmRepository.UpdateAsync(typefilm);
				}else { throw new Exception("NotFindTypeFilmWithId=" + input.Id.ToString()); }
			}
			catch (Exception ex)
			{
				throw new UserFriendlyException(ex.Message);
			}
		}
	}
}
