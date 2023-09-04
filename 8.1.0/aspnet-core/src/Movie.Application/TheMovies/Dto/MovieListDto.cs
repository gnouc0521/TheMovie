using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Movie.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.TheMovies.Dto
{
	[AutoMap(typeof(TheMovie))]
	public class MovieListDto : EntityDto<long> 
	{
		public virtual string Title { get; set; }
		public virtual string Description { get; set; } = string.Empty;
		public virtual string PathMovie { get; set; }
		public virtual string Url { get; set; }
	}
}
