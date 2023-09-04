using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Movie.Enities
{
	public class FilmPerformer : Entity<long>
	{
		public virtual string NamePerformer { get; set; }
		public virtual string DescriptionPerformer { get;set; }
		  
		public DateTime YearBirth { get; set; }
		public string Nationality { get; set; }
		public string ImgAvatar { get; set; }
		public string ImageUrl { get; set; }
		public string ImagePath { get; set; }	
	}
}
