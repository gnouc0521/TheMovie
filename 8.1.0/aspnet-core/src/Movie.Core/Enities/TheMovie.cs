using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static Movie.MovieEnum.TheMovieEnum;

namespace Movie.Enities
{
	public class TheMovie :FullAuditedEntity<long>
	{
		public virtual string Title { get; set; }
		public virtual string Description { get; set; } = string.Empty;
		
		public virtual string ShortTranslation { get; set; }	
		public virtual string LongTranslation { get; set; }
		public virtual string Image { get; set; }
		public virtual string ImageUrl { get; set; }
		public virtual string ImagePath { get; set; }
		public virtual DateTime YearRelease { get; set; }
		public virtual string Publisher { get; set; }
		public virtual string PathMovie { get; set; }
		public virtual TypeFilmEnum TypeFilm { get; set; }
		public virtual int EpisodeNumber { get; set; }
		public virtual string Url { get; set; }
	}
}
