using Abp.AutoMapper;
using Movie.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.TypeFilms.Dto
{
	[AutoMap(typeof(TypeFilm))]
	public class TypeFilmDto
	{
		public virtual string NameType { get; set; }
		public virtual string Description { get; set; } = string.Empty;
		public virtual string Code { get; set; }
	}
}
